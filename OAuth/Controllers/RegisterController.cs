using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Validation;
using Newtonsoft.Json;
using OAuth.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WebModels.auth;
using WebModels.security;

namespace OAuth.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            Client client = DataObjectFactory.Create<Client>();

            if (Request.QueryString.AllKeys.Contains("clientName", StringComparer.OrdinalIgnoreCase))
            {
                client.ClientName = Request.QueryString["clientName"];
            }

            if (Request.QueryString.AllKeys.Contains("redirectionUri", StringComparer.OrdinalIgnoreCase))
            {
                client.RedirectionURI = Request.QueryString["redirectionUri"];
            }

            if (Request.QueryString.AllKeys.Contains("postToRedirectUri", StringComparer.OrdinalIgnoreCase) && bool.TryParse(Request.QueryString["postToRedirectUri"], out bool postToRedirectUri))
            {
                ViewData["postToRedirectUri"] = postToRedirectUri;
            }

            return View(client);
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string[] keys = Request.Form.AllKeys;

            if (!keys.Contains("user"))
            {
                ModelState.AddModelError("user", "Username is a required field");
            }

            if (!keys.Contains("password"))
            {
                ModelState.AddModelError("password", "Password is a required field");
            }

            if (keys.Contains("user") && keys.Contains("password"))
            {
                string user = Request.Form["user"];
                string password = Request.Form["password"];

                if (!LDAPLogin.TryLDAPLogin(user, password))
                {
                    ModelState.AddModelError("user", "Invalid username/password");
                }

                ModelState.SetModelValue("user", new ValueProviderResult(user, user, CultureInfo.CurrentCulture));
            }

            User userObject = new Search<User>(new StringSearchCondition<User>()
            {
                Field = nameof(WebModels.security.User.Username),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = form.Get("user")
            }).GetReadOnly(null, new[] { nameof(WebModels.security.User.UserID )});

            ITransaction transaction = null;
            try
            {
                transaction = SQLProviderFactory.GenerateTransaction();
                Client client = DataObjectFactory.Create<Client>();
                client.ClientIdentifier = Guid.NewGuid();
                client.ClientName = form.Get("clientName");
                client.Type = form.Get("Type")?.Equals("BrowserEnabled", StringComparison.OrdinalIgnoreCase) ?? false ? Client.Types.BrowserEnabled : Client.Types.Device;
                client.UserID = userObject.UserID;
                client.RedirectionURI = form.Get("RedirectionURI");
                
                if (!client.Save(transaction))
                {
                    foreach (Error error in client.Errors)
                    {
                        ModelState.AddModelError(error.FieldName, error.Message);
                    }
                }

                UserClient userClient = DataObjectFactory.Create<UserClient>();
                userClient.UserID = userObject.UserID;
                userClient.ClientID = client.ClientID;
                userClient.AuthorizationTime = DateTime.Now;

                if (!userClient.Save(transaction))
                {
                    foreach (Error error in userClient.Errors)
                    {
                        ModelState.AddModelError(error.FieldName, error.Message);
                    }
                }

                if (!ModelState.IsValid)
                {
                    transaction.Rollback();
                    return View(client);
                }

                transaction.Commit();

                ViewData["ClientIdentifier"] = client.ClientIdentifier.ToString();

                if (form.Get("postToRedirectUri").Trim().Equals(bool.TrueString, StringComparison.OrdinalIgnoreCase) && client.Type == Client.Types.BrowserEnabled)
                {
                    string[] redirectUris = client.RedirectionURI.Split(';');
                    ViewData["redirect_uri"] = redirectUris[0];
                    return View("PostBack");
                }

                return View("Success");
            }
            finally
            {
                if (transaction != null && transaction.IsActive)
                {
                    transaction.Rollback();
                }
            }
        }
    }
}