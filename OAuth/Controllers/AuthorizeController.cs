using ClussPro.Base.Data.Operand;
using ClussPro.ObjectBasedFramework.DataSearch;
using Newtonsoft.Json;
using OAuth.Models;
using OAuth.Models.auth;
using OAuth.Models.security;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace OAuth.Controllers
{
    public class AuthorizeController : Controller
    {
        // GET: Authorize
        public ActionResult Index(string response_type, string client_id, string redirect_uri, string state)
        {
            if (string.IsNullOrEmpty(response_type) ||
                string.IsNullOrEmpty(client_id) ||
                string.IsNullOrEmpty(redirect_uri) ||
                string.IsNullOrEmpty(state))
            {
                return OAuthError("invalid_request", "Missing parameters");
            }

            Search<Client> clientSearch = new Search<Client>(new StringSearchCondition<Client>()
            {
                Field = "ClientIdentifier",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = client_id
            });

            Client client = clientSearch.GetReadOnly(null, new List<string>()
            {
                "RedirectionURI"
            });

            if (client == null)
            {
                return OAuthError("unauthorized_client", "The client is not authorized to request an authorization code using this method.");
            }

            if (!client.ContainsRedirectURI(redirect_uri))
            {
                return OAuthError("invalid_request", "The Redirect URI is not valid");
            }

            if (!response_type.Equals("code", System.StringComparison.OrdinalIgnoreCase))
            {
                return OAuthErrorRedirect("invalid_request", "Response Type invalid", state, redirect_uri);
            }

            ModelState.SetModelValue("client_id", new ValueProviderResult(client_id, client_id, CultureInfo.CurrentCulture));
            ModelState.SetModelValue("redirect_uri", new ValueProviderResult(redirect_uri, redirect_uri, CultureInfo.CurrentCulture));
            ModelState.SetModelValue("state", new ValueProviderResult(state, state, CultureInfo.CurrentCulture));

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string[] keys = collection.AllKeys;

            List<string> missingParameters = new List<string>();
            if (!keys.Contains("client_id") || string.IsNullOrEmpty(collection["client_id"]))
            {
                missingParameters.Add("client_id");
            }

            if (!keys.Contains("redirect_uri") || string.IsNullOrEmpty(collection["redirect_uri"]))
            {
                missingParameters.Add("redirect_uri");
            }

            if (!keys.Contains("state") || string.IsNullOrEmpty(collection["state"]))
            {
                missingParameters.Add("state");
            }

            if (missingParameters.Any())
            {
                StringBuilder builder = new StringBuilder();
                foreach (string missingParameter in missingParameters)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append(missingParameter);
                }

                return OAuthError("invalid_request", "The following parameters were not specified: " + builder.ToString());
            }

            string clientID = collection["client_id"];
            string redirectUri = collection["redirect_uri"];
            string state = collection["state"];

            Search<Client> clientSearch = new Search<Client>(new StringSearchCondition<Client>()
            {
                Field = "ClientIdentifier",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = clientID
            });

            Client client = clientSearch.GetReadOnly(null, new List<string>()
            {
                "RedirectionURI"
            });

            if (client == null)
            {
                return OAuthError("unauthorized_client", "The client is not authorized to request an authorization code using this method.");
            }

            if (!client.ContainsRedirectURI(redirectUri))
            {
                return OAuthError("invalid_request", "The Redirect URI is not valid");
            }

            if (!keys.Contains("user"))
            {
                ModelState.AddModelError("user", "Username is a required field");
            }

            if (!keys.Contains("password"))
            {
                ModelState.AddModelError("password", "Password is a required field");
            }

            if (!ModelState.IsValid)
            {
                ModelState.SetModelValue("client_id", new ValueProviderResult(clientID, clientID, CultureInfo.CurrentCulture));
                ModelState.SetModelValue("redirect_uri", new ValueProviderResult(redirectUri, redirectUri, CultureInfo.CurrentCulture));
                ModelState.SetModelValue("state", new ValueProviderResult(state, state, CultureInfo.CurrentCulture));
                if (keys.Contains("user"))
                {
                    ModelState.SetModelValue("user", new ValueProviderResult(collection["user"], collection["user"], CultureInfo.CurrentCulture));
                }
                return View(collection);
            }

            string user = collection["user"];
            string password = collection["password"];
            if (!LDAPLogin.TryLDAPLogin(user, password))
            {
                ModelState.SetModelValue("client_id", new ValueProviderResult(clientID, clientID, CultureInfo.CurrentCulture));
                ModelState.SetModelValue("redirect_uri", new ValueProviderResult(redirectUri, redirectUri, CultureInfo.CurrentCulture));
                ModelState.SetModelValue("state", new ValueProviderResult(state, state, CultureInfo.CurrentCulture));
                ModelState.SetModelValue("user", new ValueProviderResult(collection["user"], collection["user"], CultureInfo.CurrentCulture));
                ModelState.AddModelError("user", "Incorrect username/password");
                return View(collection);
            }

            Search<User> userSearch = new Search<User>(new StringSearchCondition<User>()
            {
                Field = "Username",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = user
            });

            User dbUser = userSearch.GetReadOnly(null, new string[] { "UserID" });
            if (dbUser == null)
            {
                dbUser = new User();
                dbUser.Username = user.Contains("@") ? user.Substring(0, user.IndexOf('@')) : user;
                if (!dbUser.Save())
                {
                    return OAuthErrorRedirect("server_error", "An unexpected error occurred on the server.", state, redirectUri);
                }
            }

            Code code = new Code();
            code.ClientIdentifier = Guid.Parse(clientID);
            code.AuthCode = Guid.NewGuid();
            code.RedirectURI = redirectUri;
            code.Expiration = DateTime.Now.AddMinutes(5);
            code.UserID = dbUser.UserID;
            
            if (!code.Save())
            {
                return OAuthErrorRedirect("server_error", "An unexpected error occurred on the server.", state, redirectUri);
            }

            return new RedirectResult(redirectUri + $"?code={code.AuthCode.ToString()}&state={state}", false);
        }

        private ActionResult OAuthError(string error, string error_description)
        {
            string errorResponse = JsonConvert.SerializeObject(new
            {
                error,
                error_description
            });

            Response.Output.Write(errorResponse);
            return new HttpStatusCodeResult(400);
        }

        private ActionResult OAuthErrorRedirect(string error, string error_description, string state, string redirectionUri)
        {
            return new RedirectResult(redirectionUri + $"?error={error}&error_description={error_description}&state={state}", false);
        }
    }
}