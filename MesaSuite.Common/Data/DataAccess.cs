using MesaSuite.Common.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MesaSuite.Common.Data
{
    public abstract class DataAccess
    {
        public string Resource { internal get; set; }
        public APIs API { internal get; set; }
        public bool UseHTTPS { internal get; set; } = true;
        public bool RequestSuccessful { get; protected set; }
        public bool RequireAuthentication { internal get; set; } = true;
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public List<string> RequestFields { get; set; } = new List<string>();

        public DataAccess(APIs api, string resource)
        {
            API = api;
            Resource = resource;
        }

        protected string GetResourceURI()
        {
            string resourceWriterClass = ConfigurationManager.AppSettings.Get("MesaSuite.Common.ResourceWriter." + API.ToString());
            if (string.IsNullOrEmpty(resourceWriterClass))
            {
                resourceWriterClass = ConfigurationManager.AppSettings.Get("MesaSuite.Common.ResourceWriter");
            }

            Type resourceWriterType = Assembly.GetExecutingAssembly().GetType(resourceWriterClass);
            if (resourceWriterType == null)
            {
                throw new ConfigurationErrorsException("Resource Writer must be defined in the configuration file");
            }

            IResourceWriter writer = (IResourceWriter)Activator.CreateInstance(resourceWriterType);
            return writer.Write(this);
        }

        private bool _invalidResponseRetry;
        protected delegate Task<string> ResponseWebExceptionRetryCallback();
        protected Task<string> HandleResponseWebException(WebException ex, ResponseWebExceptionRetryCallback retryCallback)
        {
            if (ex.Response != null)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    if (!_invalidResponseRetry)
                    {
                        Authentication.GetAuthToken(true);
                        _invalidResponseRetry = true;
                        return retryCallback();
                    }
                    else
                    {
                        MessageBox.Show("You must sign in to view this content", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RequestSuccessful = false;
                        return Task.FromResult<string>(null);
                    }
                }

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("You do not have sufficient permissions to view this content", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RequestSuccessful = false;
                    return Task.FromResult<string>(null);
                }

                if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    StringBuilder errorText = new StringBuilder("An error occurred with your request");

                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string additional = reader.ReadToEnd();

                        var messageObject = new { Message = string.Empty };

                        try
                        {
                            messageObject = JsonConvert.DeserializeAnonymousType(additional, messageObject);
                        }
                        catch { }

                        if (!string.IsNullOrWhiteSpace(messageObject.Message))
                        {
                            errorText = new StringBuilder(messageObject.Message);
                        }
                        else if (!string.IsNullOrEmpty(additional))
                        {
                            errorText.AppendLine();
                            errorText.Append(additional);
                        }
                    }

                    MessageBox.Show(errorText.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RequestSuccessful = false;
                    return Task.FromResult<string>(null);
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("The resource you requested was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RequestSuccessful = false;
                    return Task.FromResult<string>(null);
                }
            }

            throw ex;
        }
        
        public enum APIs
        {
            [EnumValue("mcsync")]
            MCSync,
            [EnumValue("system")]
            SystemManagement,
            [EnumValue("company")]
            CompanyStudio,
            [EnumValue("gov")]
            GovernmentPortal
        }
    }
}
