using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace API.Common.Attributes
{
    public class PresharedAuth : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string username = ConfigurationManager.AppSettings.Get("PresharedAuth.Username");
            string password = ConfigurationManager.AppSettings.Get("PresharedAuth.Password");

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            string auth = filterContext.RequestContext.HttpContext.Request.Headers.Get("Authorization"); 
            if (!auth.StartsWith("Basic "))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            auth = auth.Replace("Basic ", "");
            byte[] authBytes = Convert.FromBase64String(auth);
            auth = Encoding.UTF8.GetString(authBytes);
            string[] authParts = auth.Split(':');
            if (authParts.Length != 2)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            string authUser = authParts[0];
            string authPass = authParts[1];

            if (!authUser.Equals(username) || !authPass.Equals(password))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}