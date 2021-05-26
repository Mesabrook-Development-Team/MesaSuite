using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace OAuth.Common.Attributes
{
    public class AllowedIPsOnly : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string allowedIPString = ConfigurationManager.AppSettings.Get("AllowedIPsOnly.AllowedIPs");
            if (string.IsNullOrEmpty(allowedIPString))
            {
                throw new ArgumentNullException("AllowedIPsOnly.AllowedIPs missing from configuration");
            }

            string[] allowedIPs = allowedIPString.Split(';');
            if (!allowedIPs.Contains(actionContext.RequestContext.HttpContext.Request.ServerVariables["REMOTE_ADDR"]))
            {
                actionContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}