using Newtonsoft.Json;
using API.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.Common
{
    public static class SecurityCache
    {
        private static Dictionary<string, SecurityProfile> usersByAccessToken = new Dictionary<string, SecurityProfile>();

        public async static Task<bool> IsValid(string accessToken)
        {
            SecurityProfile profile = usersByAccessToken.FirstOrDefault(kvp => kvp.Key == accessToken).Value;

            if (profile == null || profile.Expiration < DateTime.Now)
            {
                profile = await GetSecurityProfile(accessToken);
            }

            if (profile == null || profile.Expiration < DateTime.Now)
            {
                return false;
            }

            return true;
        }

        public static SecurityProfile Get(string accessToken)
        {
            return usersByAccessToken.FirstOrDefault(kvp => kvp.Key == accessToken).Value;
        }

        public static void AddSecurityProfile(SecurityProfile profile)
        {
            usersByAccessToken[profile.AccessToken] = profile;
        }

        public static void Revoke(string accessToken)
        {
            if (usersByAccessToken.ContainsKey(accessToken))
            {
                usersByAccessToken.Remove(accessToken);
            }
        }

        private async static Task<SecurityProfile> GetSecurityProfile(string accessToken)
        {
            string user = ConfigurationManager.AppSettings.Get("OAuthUser");
            string pass = ConfigurationManager.AppSettings.Get("OAuthPass");

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                throw new ArgumentNullException("OAuthUser and OAuthPass are required settings");
            }

            string userPassConcat = $"{user}:{pass}";
            byte[] base64Bytes = Encoding.UTF8.GetBytes(userPassConcat);
            string base64String = Convert.ToBase64String(base64Bytes);

            string oAuthHost = ConfigurationManager.AppSettings.Get("OAuthHost");
            HttpWebRequest request = WebRequest.CreateHttp($"{oAuthHost}/check/token?access_token={accessToken}");
            request.Method = WebRequestMethods.Http.Get;
            request.Headers.Add("Authorization", $"Basic {base64String}");
            request.Headers.Add("Accepts", "application/json");

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();

            string json;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                json = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrEmpty(json))
            {
                return null;
            }

            var errorObject = new { error = "" };
            errorObject = JsonConvert.DeserializeAnonymousType(json, errorObject);

            if (!string.IsNullOrEmpty(errorObject.error))
            {
                throw new Exception(errorObject.error);
            }

            SecurityProfile profile = JsonConvert.DeserializeObject<SecurityProfile>(json);

            AddSecurityProfile(profile);

            return profile;
        }
    }
}