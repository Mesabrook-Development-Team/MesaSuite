using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.auth;

namespace API.Common
{
    public static class SecurityCache
    {
        private static ConcurrentDictionary<string, SecurityProfile> usersByAccessToken = new ConcurrentDictionary<string, SecurityProfile>(StringComparer.OrdinalIgnoreCase);

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
                usersByAccessToken.TryRemove(accessToken, out _);
            }
        }

        private async static Task<SecurityProfile> GetSecurityProfile(string accessToken)
        {
            if (!Guid.TryParse(accessToken, out Guid token))
            {
                return null;
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new GuidSearchCondition<Token>()
                {
                    Field = "AccessToken",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = token
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = nameof(Token.RevokeTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                }));

            Token dbToken = await Task.Run(() => tokenSearch.GetReadOnly(null, new string[] { "UserID", "Expiration", "AccessToken" }));

            if (dbToken == null)
            {
                return null;
            }

            SecurityProfile profile = new SecurityProfile()
            {
                UserID = dbToken.UserID.Value,
                AccessToken = dbToken.AccessToken.ToString(),
                Expiration = dbToken.Expiration.Value
            };

            AddSecurityProfile(profile);

            return profile;
        }
    }
}