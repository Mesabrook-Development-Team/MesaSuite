using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using WebModels.auth;

namespace OAuth.Controllers
{
    public class TokenController : Controller
    {
        [HttpPost]
        public ActionResult Index(string grant_type, string code, string redirect_uri, string client_id, string refresh_token)
        {
            Response.Headers.Add("Cache-Control", "no-store");
            Response.Headers.Add("Pragma", "no-cache");

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
                else if ("device_code".Equals(grant_type, StringComparison.OrdinalIgnoreCase))
                {
                    return CheckDeviceCode(client_id, code);
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
            token.GrantTime = DateTime.Now;
            token.UserID = userID;

            int tokenLength = int.Parse(ConfigurationManager.AppSettings.Get("TokenLifetime"));
            token.Expiration = DateTime.Now.AddSeconds(tokenLength);

            if (!token.Save())
            {
                return ErrorResponse("server_error", "An error occurred while processing the request");
            }

            dbCode.Delete();

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
                newToken.GrantTime = DateTime.Now;

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

        private ActionResult CheckDeviceCode(string client_id, string code)
        {
            Search<DeviceCode> deviceCodeSearch = new Search<DeviceCode>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And, 
                new StringSearchCondition<DeviceCode>()
                {
                    Field = nameof(DeviceCode.DeviceCodeString),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = code
                },
                new StringSearchCondition<DeviceCode>()
                {
                    Field = $"{nameof(DeviceCode.Client)}.{nameof(Client.ClientIdentifier)}",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = client_id
                }));

            DeviceCode deviceCode = deviceCodeSearch.GetEditable(readOnlyFields: new[] { "Code.UserID" });
            if (deviceCode == null)
            {
                return ErrorResponse("not_found", "The code and client id specified was not found");
            }

            int interval = int.Parse(ConfigurationManager.AppSettings.Get("DeviceCodeInterval"));
            if (DateTime.Now < deviceCode.LastPing.Value.AddSeconds(interval))
            {
                return ErrorResponse("slow_down", "You are requesting a token too often. Please wait the specified interval amount of time before requesting again.");
            }

            switch(deviceCode.Status)
            {
                case DeviceCode.Statuses.WaitingOnUser:
                    return ErrorResponse("authorization_pending", "The user has not yet authorized this app. Please try again after the specified interval.");
                case DeviceCode.Statuses.Rejected:
                    deviceCode.Delete();
                    return ErrorResponse("access_denied", "The user rejected the authorization request.");
                case DeviceCode.Statuses.Accepted:
                    Token token = DataObjectFactory.Create<Token>();
                    token.ClientID = deviceCode.ClientID;
                    token.AccessToken = Guid.NewGuid();
                    token.RefreshToken = Guid.NewGuid();
                    token.UserID = deviceCode.Code.UserID;
                    int tokenLength = int.Parse(ConfigurationManager.AppSettings.Get("TokenLifetime"));
                    token.Expiration = DateTime.Now.AddSeconds(tokenLength);
                    token.GrantTime = DateTime.Now;

                    using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
                    {
                        token.Save(transaction);
                        deviceCode.Delete(transaction);
                        bool codeDeleteSuccess = DataObject.GetEditableByPrimaryKey<Code>(deviceCode.CodeID, transaction, new string[0]).Delete(transaction);

                        if (token.Errors.Any() || deviceCode.Errors.Any() || !codeDeleteSuccess)
                        {
                            return ErrorResponse("server_error", "An unexpected error occurred on the server.");
                        }

                        transaction.Commit();
                    }

                    string json = JsonConvert.SerializeObject(new
                    {
                        access_token = token.AccessToken.ToString(),
                        token_type = "Bearer",
                        expires_in = tokenLength,
                        refresh_token = token.RefreshToken.ToString()
                    });

                    Response.Output.Write(json);

                    return new HttpStatusCodeResult(200);
                default:
                    return ErrorResponse("server_error", "An unexpected error occurred on the server.");
            }
        }

        [HttpPost]
        public ActionResult VerifyToken(string access_token)
        {
            if (!Guid.TryParse(access_token, out Guid accessToken))
            {
                using (StreamWriter writer = new StreamWriter(Response.OutputStream))
                {
                    writer.Write(JsonConvert.SerializeObject(new
                    {
                        error = "bad_request",
                        error_description = "Malformed access token"
                    }));
                }

                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Search<Token> tokenSearch = new Search<Token>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new GuidSearchCondition<Token>()
                {
                    Field = nameof(Token.AccessToken),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = accessToken
                },
                new DateTimeSearchCondition<Token>()
                {
                    Field = nameof(Token.RevokeTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Null
                }));

            return tokenSearch.ExecuteExists(null) ? new HttpStatusCodeResult(System.Net.HttpStatusCode.OK) : new HttpStatusCodeResult(System.Net.HttpStatusCode.Unauthorized);
        }
    }
}