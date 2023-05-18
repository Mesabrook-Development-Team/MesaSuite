﻿using ClussPro.Base.Data.Operand;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using Newtonsoft.Json;
using OAuth.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebModels.auth;
using WebModels.security;

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

            string clientID = collection["client_id"];
            Search<Client> clientSearch = new Search<Client>(new StringSearchCondition<Client>()
            {
                Field = "ClientIdentifier",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = clientID
            });

            Client client = clientSearch.GetReadOnly(null, FieldPathUtility.CreateFieldPathsAsList<Client>(c => new List<object>()
            {
                c.RedirectionURI,
                c.UserClients.First().UserID
            }));

            if (client == null)
            {
                return OAuthError("unauthorized_client", "The client is not authorized to request an authorization code using this method.");
            }

            //if (keys.Contains("response_type") && "device_code".Equals(collection["response_type"], StringComparison.OrdinalIgnoreCase))
            //{
            //    return HandleDeviceCodeResponse(collection["client_id"]);
            //}

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

            string redirectUri = collection["redirect_uri"];
            string state = collection["state"];

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
                dbUser = DataObjectFactory.Create<User>();
                dbUser.Username = user.Contains("@") ? user.Substring(0, user.IndexOf('@')) : user;
                if (!dbUser.Save())
                {
                    return OAuthErrorRedirect("server_error", "An unexpected error occurred on the server.", state, redirectUri);
                }
            }

            if (!client.UserClients?.Any(uc => uc.UserID == dbUser.UserID) ?? false)
            {
                TempData["ClientID"] = clientID;
                TempData["State"] = state;
                TempData["RedirectUri"] = redirectUri;
                TempData["NoRedirect"] = collection.AllKeys.Contains("noredirect") ? collection.Get("noredirect") : bool.FalseString;
                TempData["UserID"] = dbUser.UserID.ToString();
                return RedirectToAction("AppGrant");
            }

            return CreateOAuthCode(Guid.Parse(clientID), dbUser.UserID.Value, redirectUri, state, collection.AllKeys.Contains("noredirect") && bool.TryParse(collection.Get("noredirect"), out bool noRedirect) ? noRedirect : false);
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

        private ActionResult HandleDeviceCodeResponse(string client_id)
        {
            if (!Guid.TryParse(client_id, out Guid device_id))
            {
                return OAuthError("invalid_request", "client_id must be a GUID");
            }

            Search<Client> clientSearch = new Search<Client>(new GuidSearchCondition<Client>()
            {
                Field = nameof(Client.ClientIdentifier),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = device_id
            });

            Client client = clientSearch.GetReadOnly(null, new[] { "ClientID", "Type" });
            if (client == null)
            {
                client = DataObjectFactory.Create<Client>();
                client.ClientIdentifier = device_id;
                client.Type = Client.Types.Device;
                if (!client.Save())
                {
                    Response.Output.Write(JsonConvert.SerializeObject(new { error = "server_error", error_description = "An unexpected error occurred on the server" }));
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.InternalServerError);
                }
            }
            else if (client.Type != Client.Types.Device)
            {
                return OAuthError("unauthorized_client", "The client is not authorized to request an authorization code using this method.");
            }

            

            return Json(new
            {
                verification_uri = Request.Url.GetLeftPart(UriPartial.Authority) + "/device",

            });
        }

        [HttpGet]
        public ActionResult AppGrant()
        {
            if (!TempData.ContainsKey("ClientID") || !TempData.ContainsKey("State") || !TempData.ContainsKey("RedirectUri"))
            {
                Response.Output.WriteLine("Bad Request");
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            string clientID = TempData["ClientID"] as string;
            Client client = new Search<Client>(new StringSearchCondition<Client>()
            {
                Field = nameof(Client.ClientIdentifier),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = clientID
            }).GetReadOnly(null, new[] { nameof(Client.ClientName) });

            ViewBag.ClientName = client?.ClientName;

            ViewData["ClientID"] = TempData["ClientID"];
            ViewData["State"] = TempData["State"];
            ViewData["RedirectUri"] = TempData["RedirectUri"];
            ViewData["NoRedirect"] = TempData["NoRedirect"];
            ViewData["UserID"] = TempData["UserID"];

            TempData.Clear();

            return View();
        }

        [HttpPost]
        public ActionResult AppGrant(FormCollection form)
        {
            if (!form.AllKeys.Contains("ClientID") ||
                !form.AllKeys.Contains("State") ||
                !form.AllKeys.Contains("RedirectUri") ||
                !form.AllKeys.Contains("UserID"))
            {
                return OAuthError("bad_request", "Required information was missing");
            }

            if (!form.AllKeys.Contains("allow"))
            {
                return OAuthErrorRedirect("unauthorized", "The user rejected authorization of the client", form.Get("State"), form.Get("RedirectUri"));
            }

            if (!Guid.TryParse(form.Get("ClientID"), out Guid clientID))
            {
                return OAuthError("bad_request", "ClientID must be a guid");
            }

            if (!long.TryParse(form.Get("UserID"), out long userID))
            {
                return OAuthError("bad_request", "UserID must be a long");
            }

            Client client = new Search<Client>(new GuidSearchCondition<Client>()
            {
                Field = nameof(Client.ClientIdentifier),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = clientID
            }).GetReadOnly(null, new[] { nameof(Client.ClientID) });

            if (client == null)
            {
                return OAuthErrorRedirect("unauthorized", "The client is not authorized to request an authorization code using this method.", form.Get("State"), form.Get("RedirectUri"));
            }

            UserClient userClient = DataObjectFactory.Create<UserClient>();
            userClient.UserID = userID;
            userClient.ClientID = client.ClientID;
            userClient.AuthorizationTime = DateTime.Now;
            userClient.Save();

            return CreateOAuthCode(clientID, userID, form.Get("RedirectUri"), form.Get("State"), form.AllKeys.Contains("NoRedirect") && form.Get("NoRedirect").Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase));
        }

        private ActionResult CreateOAuthCode(Guid clientID, long userID, string redirectUri, string state, bool noRedirect)
        {
            Code code = DataObjectFactory.Create<Code>();
            code.ClientIdentifier = clientID;
            code.AuthCode = Guid.NewGuid();
            code.RedirectURI = redirectUri;
            code.Expiration = DateTime.Now.AddMinutes(5);
            code.UserID = userID;

            if (!code.Save())
            {
                return OAuthErrorRedirect("server_error", "An unexpected error occurred on the server.", state, redirectUri);
            }

            if (noRedirect)
            {
                Response.Output.WriteLine($"code={code.AuthCode.ToString()}&state={state}");
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            }

            return new RedirectResult($"{code.RedirectURI}?code={code.AuthCode.ToString()}&state={state}", false);
        }
    }
}