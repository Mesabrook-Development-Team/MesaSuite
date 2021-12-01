using MesaSuite.Common.Data;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common
{
    public static class Authentication
    {
        public static event EventHandler OnLoggedIn;
        public static event EventHandler OnLoggedOut;
        public static event EventHandler OnProgramUpdate;
        private static AuthenticationStatuses _authenticationStatus = AuthenticationStatuses.LoggedOut;
        public static AuthenticationStatuses AuthenticationStatus
        {
            get { return _authenticationStatus; }
            private set
            {
                _authenticationStatus = value;
                if (_authenticationStatus == AuthenticationStatuses.LoggedIn)
                {
                    OnLoggedIn?.Invoke(null, new EventArgs());
                }
                else
                {
                    OnLoggedOut?.Invoke(null, new EventArgs());
                }
            }
        }
        private static Thread programThread;

        private static List<string> _programs = new List<string>();
        public static IReadOnlyCollection<string> Programs => _programs;

        public static readonly int[] PORTS = new int[] { 48170, 48171, 48172, 48173, 48174 };
        private static Guid? _clientID = null;
        private static Guid? ClientID
        {
            get
            {
                if (_clientID == null)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
                    string clientIDKey;

#if DEBUG
                    clientIDKey = "ClientIDDev";
#else
                    clientIDKey = "ClientID";
#endif

                    string clientIDString = key.GetValue(clientIDKey) as string;
                    if (Guid.TryParse(clientIDString, out Guid clientID))
                    {
                        _clientID = clientID;
                    }
                }

                return _clientID;
            }
            set
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
                string clientIDKey;

#if DEBUG
                clientIDKey = "ClientIDDev";
#else
                clientIDKey = "ClientID";
#endif

                if (value != null)
                {
                    key.SetValue(clientIDKey, value.ToString());
                }
                else
                {
                    key.DeleteValue(clientIDKey);
                }
            }
        }
        private static string AuthToken { get; set; }
        private static string RefreshToken { get; set; }
        private static DateTime Expiration { get; set; }

        public static string GetAuthToken(bool doLogIn = false)
        {
            if (string.IsNullOrEmpty(AuthToken) && doLogIn)
            {
                DoLogIn();
            }

            if (!string.IsNullOrEmpty(AuthToken) && Expiration <= DateTime.Now)
            {
                RefreshTokenRequest();
            }

            return AuthToken;
        }

        public static void Register()
        {
            if (ClientID == null)
            {
                ClientID = Guid.NewGuid();
            }

            frmRegister register = new frmRegister();
            register.ClientID = ClientID.Value;
            register.ShowDialog();
        }

        private static void DoLogIn()
        {
            if (ClientID == null)
            {
                Register();
            }

            int openPort = -1;
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            IPEndPoint[] listeners = properties.GetActiveTcpListeners();
            foreach (int port in PORTS)
            {
                if (connections.Any(connection => connection.LocalEndPoint.Port == port) || listeners.Any(ipListener => ipListener.Port == port))
                {
                    continue;
                }

                openPort = port;
                break;
            }

            if (openPort == -1)
            {
                throw new Exception("Could not open a port for authentication");
            }

            Guid state = Guid.NewGuid();
            frmLogin login = new frmLogin();
            login.Port = openPort;
            login.ClientID = ClientID.Value;
            login.State = state;
            login.DialogResult = DialogResult.Cancel;

            HttpListener listener = null;
            try
            {
                listener = new HttpListener();
                ListenForResponse(listener, login, openPort, state);

                DialogResult result = login.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            finally
            {
                listener.Close();
            }

            if (!string.IsNullOrEmpty(AuthToken))
            {
                AuthenticationStatus = AuthenticationStatuses.LoggedIn;
            }
        }

        private static async void ListenForResponse(HttpListener listener, frmLogin login, int openPort, Guid state)
        {
            listener.Prefixes.Add("http://localhost:" + openPort + "/");
            listener.Start();
            HttpListenerContext context;
            try
            {
                context = await listener.GetContextAsync();
            }
            catch(Exception ex) { return; }

            HttpListenerRequest request = context.Request;
            if (request.QueryString.AllKeys.Contains("error"))
            {
                ResetValues();

                string error = request.QueryString["error"];
                string error_description = request.QueryString.Get("error_description");

                login.Invoke(new MethodInvoker(() =>
                {
                    MessageBox.Show(error + ":\r\n" + error_description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    login.Close();
                }));
                AuthenticationStatus = AuthenticationStatuses.LoggedOut;
            }
            else
            {
                string responseStateString = request.QueryString.Get("state");
                if (!Guid.TryParse(responseStateString, out Guid responseState) || !responseState.Equals(state))
                {
                    ResetValues();

                    login.Invoke(new MethodInvoker(() =>
                    {
                        MessageBox.Show("Sign in rejected by MesaSuite.  Anti-CSRF check failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        login.Close();
                    }));
                    AuthenticationStatus = AuthenticationStatuses.LoggedOut;
                }

                string code = request.QueryString.Get("code");
                AccessTokenRequest(login, openPort, code);
            }
        }

        private static void AccessTokenRequest(frmLogin login, int openPort, string code)
        {
            WebClient client = new WebClient();

            string responseString = null;
            try
            {
                client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
                responseString = client.UploadString(new Uri($"{ConfigurationManager.AppSettings.Get("MesaSuite.Common.AuthHost")}/Token"), "POST", $"grant_type=authorization_code&code={code}&redirect_uri={WebUtility.UrlEncode("http://localhost:" + openPort)}&client_id={ClientID.ToString()}");
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            var successObject = new
            {
                access_token = "",
                token_type = "",
                expires_in = -1,
                refresh_token = ""
            };

            var failedObject = new
            {
                error = "",
                error_description = ""
            };

            successObject = JsonConvert.DeserializeAnonymousType(responseString, successObject);
            failedObject = JsonConvert.DeserializeAnonymousType(responseString, failedObject);

            if (!string.IsNullOrEmpty(successObject.access_token))
            {
                AuthToken = successObject.access_token;
                RefreshToken = successObject.refresh_token;
                Expiration = DateTime.Now.AddSeconds(successObject.expires_in);

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
                key.SetValue("AuthToken", AuthToken);
                key.SetValue("RefreshToken", RefreshToken);
                key.SetValue("Expiration", Expiration.ToBinary());

                UpdatePrograms();
            }
            else
            {
                ResetValues();

                login.Invoke(new MethodInvoker(() =>
                {
                    MessageBox.Show(failedObject.error + ":\r\n" + failedObject.error_description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    login.Close();
                }));
                AuthenticationStatus = AuthenticationStatuses.LoggedOut;
            }

            login.Invoke(new MethodInvoker(() =>
            {
                login.DialogResult = DialogResult.OK;
                login.Close();
            }));
        }

        private static void RefreshTokenRequest()
        {
            WebClient refreshClient = new WebClient();
            refreshClient.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");

            string responseString = null;
            try
            {
                responseString = refreshClient.UploadString($"{ConfigurationManager.AppSettings.Get("MesaSuite.Common.AuthHost")}/token", $"grant_type=refresh_token&refresh_token={RefreshToken.ToString()}");
            }
            catch(WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            var successObject = new
            {
                access_token = "",
                token_type = "",
                expires_in = -1,
                refresh_token = ""
            };

            var failedObject = new
            {
                error = "",

                error_description = ""
            };

            successObject = JsonConvert.DeserializeAnonymousType(responseString, successObject);
            failedObject = JsonConvert.DeserializeAnonymousType(responseString, failedObject);

            if (!string.IsNullOrEmpty(successObject.access_token))
            {
                AuthToken = successObject.access_token;
                RefreshToken = successObject.refresh_token;
                Expiration = DateTime.Now.AddSeconds(successObject.expires_in);

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
                key.SetValue("AuthToken", AuthToken);
                key.SetValue("RefreshToken", RefreshToken);
                key.SetValue("Expiration", Expiration.ToBinary());

                UpdatePrograms();
            }
            else
            {
                ResetValues();
                AuthenticationStatus = AuthenticationStatuses.LoggedOut;

                throw new Exception(failedObject.error + ":\r\n" + failedObject.error_description);
            }
        }

        public static void LogOut()
        {
            if (AuthenticationStatus == AuthenticationStatuses.LoggedOut || string.IsNullOrEmpty(GetAuthToken()))
            {
                return;
            }

            string authToken = GetAuthToken();

            WebClient logOutClient = new WebClient();
            logOutClient.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            logOutClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + authToken);

            try
            {
                logOutClient.UploadString($"{ConfigurationManager.AppSettings.Get("MesaSuite.Common.AuthHost")}/revoke", "reason=" + WebUtility.UrlEncode("Log Out"));
            }
            catch(WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (response.Headers.AllKeys.Contains("WWW-Authenticate"))
                {
                    ResetValues();
                    AuthenticationStatus = AuthenticationStatuses.LoggedOut;
                    return;
                }

#if DEBUG
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseString = reader.ReadToEnd();
                    Debugger.Break();
                }
#endif

                throw new Exception("An error occurred while attempting to log out.  Cannot guarantee revoke completed successfully.");
            }

            ResetValues();
            AuthenticationStatus = AuthenticationStatuses.LoggedOut;
        }

        public static void Initialize()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
            long? expirationEncoded = key.GetValue("Expiration") as long?;

            if (expirationEncoded != null)
            {
                Expiration = DateTime.FromBinary(expirationEncoded.Value);
            }

            AuthToken = key.GetValue("AuthToken") as string;
            RefreshToken = key.GetValue("RefreshToken") as string;

            AuthenticationStatus = string.IsNullOrEmpty(AuthToken) ? AuthenticationStatuses.LoggedOut : AuthenticationStatuses.LoggedIn;

            programThread = new Thread(new ThreadStart(ProgramThreadLogic));
            programThread.Start();
        }

        public static void Shutdown()
        {
            _requestProgramThreadStop = true;
        }

        private static bool _requestProgramThreadStop = false;
        private static void ProgramThreadLogic()
        {
            do
            {
                try
                {
                    UpdatePrograms();

                    if (Application.OpenForms.Count == 0)
                    {
                        break;
                    }
                }
                catch (Exception) { }

                Thread.Sleep(10000);
            }
            while (!_requestProgramThreadStop);
        }

        private static bool isUpdatingPrograms = false;
        public async static Task UpdatePrograms()
        {
            if (isUpdatingPrograms) { return; }

            isUpdatingPrograms = true;
            try
            {
                List<string> newPrograms;

                if (!string.IsNullOrEmpty(GetAuthToken()))
                {
                    GetData getData = new GetData(DataAccess.APIs.SystemManagement, "Program/GetCurrentPrograms");

                    try
                    {
                        newPrograms = await getData.GetObject<List<string>>() ?? new List<string>();
                    }
                    catch (Exception)
                    {
                        newPrograms = new List<string>();
                    }
                }
                else
                {
                    newPrograms = new List<string>();
                }

                List<string> currentPrograms = _programs.ToList();

                bool hasChanges = newPrograms.Count != currentPrograms.Count || newPrograms.Any(np => currentPrograms.Contains(np)) || currentPrograms.Any(cp => newPrograms.Contains(cp));
                _programs = newPrograms;

                if (hasChanges)
                {
                    OnProgramUpdate?.Invoke(Programs, new EventArgs());
                }
            }
            finally
            {
                isUpdatingPrograms = false;
            }
        }

        public enum AuthenticationStatuses
        {
            LoggedIn,
            LoggedOut
        }

        private static void ResetValues()
        {
            AuthToken = null;
            RefreshToken = null;
            Expiration = DateTime.Now;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Clussman Productions\MesaSuite");
            key.DeleteValue("AuthToken");
            key.DeleteValue("RefreshToken");

            UpdatePrograms();
        }
    }
}
