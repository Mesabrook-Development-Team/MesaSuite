using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using WebModels.auth;

namespace OAuth.Controllers
{
    public class TokenController : Controller
    {
        [HttpPost]
        public ActionResult Index(string grant_type, string code, string redirect_uri, string client_id, string refresh_token)
        {
            if (!string.IsNullOrEmpty(grant_type))
            {
                if ("authorization_code".Equals(grant_type, StringComparison.OrdinalIgnoreCase))
                {
                    return AuthCode(code, redirect_uri, client_id);
                }
                else if ("refresh_token".Equals(grant_type, StringComparison.OrdinalIgnoreCase))
                {
                    return Refresh(refresh_token);
                }
            }

            return ErrorResponse("invalid_request", "Grant type not known");
        }

        private ActionResult AuthCode(string code, string redirect_uri, string client_id)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(redirect_uri) || string.IsNullOrEmpty(client_id) || !Guid.TryParse(client_id, out Guid client_id_guid))
            {
                return ErrorResponse("invalid_request", "Missing required parameters");
            }

            Search<Client> clientSearch = new Search<Client>(new StringSearchCondition<Client>()
            {
                Field = "ClientIdentifier",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = client_id
            });

            Client client = clientSearch.GetReadOnly(null, new List<string>() { "ClientID" });

            if (client == null)
            {
                return ErrorResponse("invalid_client", "Unknown client");
            }

            Search<Code> codeSearch = new Search<Code>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<Code>()
                {
                    Field = "AuthCode",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = code
                },
                new GuidSearchCondition<Code>()
                {
                    Field = "ClientIdentifier",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = client_id_guid
                },
                new StringSearchCondition<Code>()
                {
                    Field = "RedirectURI",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = redirect_uri
                }));

            Code dbCode = codeSearch.GetEditable(null, Enumerable.Empty<string>());
            long? userID = dbCode.UserID;
            if (dbCode == null || dbCode.Expiration < DateTime.Now)
            {
                if (dbCode != null)
                {
                    dbCode.Delete();
                }

                return ErrorResponse("invalid_grant", "The provided authorization grant (e.g., authorization code, resource owner credentials) or refresh token is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client.");
            }

            Token token = DataObjectFactory.Create<Token>();
            token.ClientID = client.ClientID;
            token.AccessToken = Guid.NewGuid();
            token.RefreshToken = Guid.NewGuid();
            token.UserID = userID;

            int tokenLength = int.Parse(ConfigurationManager.AppSettings.Get("TokenLifetime"));
            token.Expiration = DateTime.Now.AddSeconds(tokenLength);

            if (!token.Save())
            {
                return ErrorResponse("server_error", "An error occurred while processing the request");
            }

            dbCode.Delete();

            Response.Headers.Add("Cache-Control", "no-store");
            Response.Headers.Add("Pragma", "no-cache");

            string json = JsonConvert.SerializeObject(new
            {
                access_token = token.AccessToken.ToString(),
                token_type = "Bearer",
                expires_in = tokenLength,
                refresh_token = token.RefreshToken.ToString()
            });

            Response.Output.Write(json);

            return new HttpStatusCodeResult(200);
        }

        private ActionResult Refresh(string refresh_token)
        {
            if (string.IsNullOrEmpty(refresh_token))
            {
                return ErrorResponse("invalid_request", "Missing required parameters");
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<Token>()
                {
                    Field = "RefreshToken",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = refresh_token
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = "RevokeTime",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                },
                new BooleanSearchCondition<Token>()
                {
                    Field = "RefreshTokenUsed",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = false
                }));

            Token token = tokenSearch.GetEditable(null, Enumerable.Empty<string>());
            if (token == null)
            {
                return ErrorResponse("invalid_grant", "The provided authorization grant (e.g., authorization code, resource owner credentials) or refresh token is invalid, expired, revoked, does not match the redirection URI used in the authorization request, or was issued to another client.");
            }

            Token newToken = null;
            string expirationString = ConfigurationManager.AppSettings.Get("TokenLifetime");
            int expirationSeconds = int.Parse(expirationString);
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                token.RefreshTokenUsed = true;
                if (!token.Save(transaction))
                {
                    transaction.Rollback();
                    return ErrorResponse("server_error", "An error occurred processing the request");
                }

                newToken = DataObjectFactory.Create<Token>();
                newToken.ClientID = token.ClientID;
                newToken.AccessToken = Guid.NewGuid();
                newToken.RefreshToken = Guid.NewGuid();
                newToken.UserID = token.UserID;

                newToken.Expiration = DateTime.Now.AddSeconds(expirationSeconds);
                
                if (!newToken.Save(transaction))
                {
                    transaction.Rollback();
                    return ErrorResponse("server_error", "An error occurred processing the request");
                }

                transaction.Commit();
            }

            var responseObject = new
            {
                access_token = newToken.AccessToken.ToString(),
                token_type = "Bearer",
                expires_in = expirationSeconds,
                refresh_token = newToken.RefreshToken.ToString()
            };

            string responseJson = JsonConvert.SerializeObject(responseObject);

            Response.Output.Write(responseJson);

            return new HttpStatusCodeResult(200);
        }

        private ActionResult ErrorResponse(string error, string error_description)
        {
            string json = JsonConvert.SerializeObject(new { error, error_description });

            Response.Output.Write(json);
            return new HttpStatusCodeResult(400);
        }
    }
}