using ClussPro.ObjectBasedFramework.DataSearch;
using Newtonsoft.Json;
using OAuth.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebModels.auth;
using WebModels.security;

namespace OAuth.App_Code
{
    public static class SecurityCache
    {
        private static Dictionary<string, SecurityProfile> securityProfilesByToken = new Dictionary<string, SecurityProfile>();
        private static Dictionary<long, List<SecurityProfile>> securityProfilesByUserID = new Dictionary<long, List<SecurityProfile>>();

        public async static Task<bool> IsValid(string accessToken)
        {
            SecurityProfile profile = securityProfilesByToken.FirstOrDefault(kvp => kvp.Key == accessToken).Value;

            if (profile == null || profile.Expiration < DateTime.Now)
            {
                profile = await QueryForAccessToken(accessToken);
            }

            if (profile == null || profile.Expiration < DateTime.Now)
            {
                return false;
            }

            return true;
        }

        private async static Task<SecurityProfile> QueryForAccessToken(string accessToken)
        {
            Search<Token> tokenSearch = new Search<Token>(new StringSearchCondition<Token>()
            {
                Field = "AccessToken",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = accessToken
            });

            if (!tokenSearch.ExecuteExists(null))
            {
                return null;
            }

            Token token = await Task.Run(() => tokenSearch.GetReadOnly(null, new string[] { "AccessToken", "Expiration", "UserID"}));

            SecurityProfile securityProfile = new SecurityProfile();
            securityProfile.AccessToken = token.AccessToken.ToString();
            securityProfile.Expiration = token.Expiration.Value;
            securityProfile.UserID = token.UserID.Value;
            AddSecurityProfile(securityProfile);

            return securityProfile;
        }

        public async static Task<SecurityProfile> Get(string accessToken, bool queryIfNotFound = false)
        {
            if (securityProfilesByToken.ContainsKey(accessToken))
            {
                return securityProfilesByToken[accessToken];
            }
            else if (queryIfNotFound)
            {
                return await QueryForAccessToken(accessToken);
            }

            return null;
        }

        public static async Task UpdatePermissionsForUserID(long userID)
        {
            if (!securityProfilesByUserID.ContainsKey(userID))
            {
                return;
            }

            Search<UserPermission> userPermission = new Search<UserPermission>(new LongSearchCondition<UserPermission>()
            {
                Field = "UserID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = userID
            });

            List<Permission> permissionsForUser = await Task.Run(() => userPermission.GetReadOnlyReader(null, new string[] { "Permission.Key" }).Select(up => up.Permission).ToList());
            foreach(SecurityProfile profile in securityProfilesByUserID[userID].Where(sp => sp.Expiration > DateTime.Now))
            {
                profile.Permissions = permissionsForUser.Select(p => p.Key).ToList();
                NotifyGrants(profile);
            }
        }

        public static void AddSecurityProfile(SecurityProfile profile)
        {
            securityProfilesByToken[profile.AccessToken] = profile;
            if (!securityProfilesByUserID.ContainsKey(profile.UserID))
            {
                securityProfilesByUserID[profile.UserID] = new List<SecurityProfile>();
            }

            securityProfilesByUserID[profile.UserID].Add(profile);

            NotifyGrants(profile);
        }

        public static void Revoke(string accessToken)
        {
            SecurityProfile profile = null;
            if (securityProfilesByToken.ContainsKey(accessToken))
            {
                profile = securityProfilesByToken[accessToken];
                securityProfilesByToken.Remove(accessToken);
            }

            if (profile != null && securityProfilesByUserID.ContainsKey(profile.UserID))
            {
                securityProfilesByUserID[profile.UserID].Remove(profile);

                if (!securityProfilesByUserID[profile.UserID].Any())
                {
                    securityProfilesByUserID.Remove(profile.UserID);
                }
            }

            NotifyRevokes(accessToken);
        }

        public static void Revoke(long userID)
        {
            if (!securityProfilesByUserID.ContainsKey(userID))
            {
                return;
            }

            foreach(SecurityProfile profile in securityProfilesByUserID[userID])
            {
                securityProfilesByToken[profile.AccessToken] = null;
                NotifyRevokes(profile.AccessToken);
            }

            securityProfilesByUserID[userID] = null;
        }

        private static void NotifyGrants(SecurityProfile profile)
        {
            string notifications = ConfigurationManager.AppSettings.Get("TokenGrantNotifications");
            if (string.IsNullOrEmpty(notifications))
            {
                return;
            }

            string user = ConfigurationManager.AppSettings.Get("NotificationUsername");
            string pass = ConfigurationManager.AppSettings.Get("NotificationPassword");

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                throw new ArgumentNullException("NotificationUsername and NotificationPassword are required to send notifications");
            }

            byte[] base64Bytes = Encoding.UTF8.GetBytes($"{user}:{pass}");
            string base64String = Convert.ToBase64String(base64Bytes);

            string[] uris = notifications.Split(';');

            foreach(string uri in uris)
            {
                HttpWebRequest grantNotification = WebRequest.CreateHttp(uri);
                grantNotification.Method = WebRequestMethods.Http.Post;
                grantNotification.Headers.Add("Authorization", $"Basic {base64String}");
                grantNotification.ContentType = "application/json";

                using (StreamWriter writer = new StreamWriter(grantNotification.GetRequestStream()))
                {
                    writer.Write(JsonConvert.SerializeObject(profile));
                }

                try
                {
                    grantNotification.GetResponseAsync();
                }
                catch (Exception) { }
            }
        }

        private static void NotifyRevokes(string accessToken)
        {
            string notifications = ConfigurationManager.AppSettings.Get("TokenRevokeNotifications");
            if (string.IsNullOrEmpty(notifications))
            {
                return;
            }

            string user = ConfigurationManager.AppSettings.Get("NotificationUsername");
            string pass = ConfigurationManager.AppSettings.Get("NotificationPassword");

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                throw new ArgumentNullException("NotificationUsername and NotificationPassword are required to send notifications");
            }

            byte[] base64Bytes = Encoding.UTF8.GetBytes($"{user}:{pass}");
            string base64String = Convert.ToBase64String(base64Bytes);

            string[] uris = notifications.Split(';');

            foreach (string uri in uris)
            {
                HttpWebRequest revokeNotification = WebRequest.CreateHttp(uri);
                revokeNotification.Method = WebRequestMethods.Http.Post;
                revokeNotification.Headers.Add("Authorization", $"Basic {base64String}");
                revokeNotification.ContentType = "application/json";

                using (StreamWriter writer = new StreamWriter(revokeNotification.GetRequestStream()))
                {
                    writer.Write(JsonConvert.SerializeObject(new { token = accessToken }));
                }

                try
                {
                    revokeNotification.GetResponseAsync();
                }
                catch (Exception) { }
            }
        }
    }
}