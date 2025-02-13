using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MesaService.Utility
{
    internal static class DiscordHelper
    {
        public static bool SendDiscordMessage(string discordID, string usernameRecipient, string message)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"{ConfigurationManager.AppSettings.Get("DiscordBotBaseURL")}/send/{Uri.EscapeDataString(message)}?userId={discordID}");
            request.Method = "POST";
            request.Headers.Add("api-key", ConfigurationManager.AppSettings.Get("DiscordBotAPIKey"));

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string data;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    data = reader.ReadToEnd();
                }

                var errorObject = new
                {
                    Error = "",
                    ErrorCode = ""
                };

                errorObject = JsonConvert.DeserializeAnonymousType(data, errorObject);
                if (!string.IsNullOrEmpty(errorObject.ErrorCode))
                {
                    switch (errorObject.ErrorCode)
                    {
                        case "54": // User blocked bot
                            HandleDiscordError($"User '{usernameRecipient}' has blocked the Mesabrook Bot");
                            break;
                        case "53": // User not found
                            HandleDiscordError($"User '{usernameRecipient}' has an invalid Discord ID");
                            break;
                    }

                    return false;
                }

                return true;
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null && webEx.Response is HttpWebResponse webExResponse && webExResponse.StatusCode == (HttpStatusCode)429)
                {
                    return false;
                }

                throw webEx;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred sending inactivity message: {ex.Message}");
                HandleDiscordError($"An error occurred attempting to notify '{usernameRecipient}' of their upcoming inactivity period: {ex.Message}");

                return false;
            }
        }

        private static void HandleDiscordError(string errorToSend)
        {
            string errorDiscordID = ConfigurationManager.AppSettings.Get("DiscordIDErrorNotification");

            string message = $"***Mesabrook Department of Internal Affairs***\r\n*Mesabrook Bot Error Notification**\r\n\r\n{errorToSend}";
            HttpWebRequest request = WebRequest.CreateHttp($"{ConfigurationManager.AppSettings.Get("DiscordBotBaseURL")}/send/{Uri.EscapeDataString(message)}?userId={errorDiscordID}");
            request.Method = "POST";
            request.Headers.Add("api-key", ConfigurationManager.AppSettings.Get("DiscordBotAPIKey"));

            try
            {
                request.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred sending message error notification: {ex.Message}");
            }
        }
    }
}
