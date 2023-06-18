using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using OAuth.Models;
using WebModels.auth;
using WebModels.security;

namespace OAuth.Controllers
{
    public class DeviceController : Controller
    {
        // GET: Device
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerifyCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Json(new
                {
                    success = false
                });
            }

            Search<DeviceCode> codeSearch = new Search<DeviceCode>(new StringSearchCondition<DeviceCode>()
            {
                Field = nameof(DeviceCode.UserCode),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = code
            });

            return Json(new
            {
                success = codeSearch.ExecuteExists(null)
            });
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (!form.AllKeys.Contains("UserCode", StringComparer.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("UserCode", "User Code is a required field");
            }

            if (!form.AllKeys.Contains("Username", StringComparer.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("Username", "Username is a required field");
            }

            if (!form.AllKeys.Contains("Password", StringComparer.OrdinalIgnoreCase))
            {
                ModelState.AddModelError("Password", "Password is a required field");
            }

            ModelState.SetModelValue("Username", new ValueProviderResult(form.Get("Username"), form.Get("Username"), CultureInfo.CurrentCulture));
            ModelState.SetModelValue("UserCode", new ValueProviderResult(form.Get("UserCode"), form.Get("UserCode"), CultureInfo.CurrentCulture));
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            if (!LDAPLogin.TryLDAPLogin(form.Get("Username"), form.Get("Password")))
            {
                ModelState.AddModelError("Username", "Incorrect username/password");
                return View(form);
            }

            User user = new Search<User>(new StringSearchCondition<User>()
            {
                Field = nameof(WebModels.security.User.Username),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = form.Get("Username")
            }).GetReadOnly(null, new[] { nameof(WebModels.security.User.UserID) });

            if (user == null)
            {
                ModelState.AddModelError("Username", "Incorrect username/password");
                return View(form);
            }

            Search<DeviceCode> deviceCodeSearch = new Search<DeviceCode>(new StringSearchCondition<DeviceCode>()
            {
                Field = nameof(DeviceCode.UserCode),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = form.Get("UserCode")
            });
            DeviceCode deviceCode = deviceCodeSearch.GetEditable(readOnlyFields: FieldPathUtility.CreateFieldPathsAsList<DeviceCode>(dc => new List<object>()
            {
                dc.Client.ClientIdentifier,
                dc.Client.UserClients.First().UserID
            }));

            if (deviceCode == null)
            {
                ModelState.AddModelError("UserCode", "This code isn't valid");
                return View(form);
            }

            if (!deviceCode.Client?.UserClients?.Any(uc => uc.UserID == user.UserID) ?? false)
            {
                TempData["ClientID"] = deviceCode.Client.ClientIdentifier.ToString();
                TempData["UserID"] = user.UserID.ToString();
                TempData["DeviceCodeID"] = deviceCode.DeviceCodeID.ToString();
                TempData["RequestType"] = "device_code";

                return RedirectToAction("AppGrant", "Authorize");
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                Code code = DataObjectFactory.Create<Code>();
                code.UserID = user.UserID;
                code.AuthCode = Guid.NewGuid();
                code.ClientIdentifier = deviceCode.Client.ClientIdentifier;
                code.Expiration = DateTime.Now.AddMinutes(5);
                if (!code.Save(transaction))
                {
                    string errors = string.Join(". ", code.Errors.Select(e => e.Message));
                    ModelState.AddModelError("UserCode", errors);

                    return View(form);
                }

                deviceCode.CodeID = code.CodeID;
                deviceCode.Status = DeviceCode.Statuses.Accepted;
                if (!deviceCode.Save(transaction))
                {
                    string errors = string.Join(". ", deviceCode.Errors.Select(e => e.Message));
                    ModelState.AddModelError("UserCode", errors);

                    return View(form);
                }

                transaction.Commit();
            }

            return View("Success");
        }
    }
}