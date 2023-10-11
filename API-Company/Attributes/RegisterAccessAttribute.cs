using API.Common;
using API_Company.App_Code;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API_Company.Attributes
{
    internal class RegisterAccessAttribute : ActionFilterAttribute
    {
        public bool RequireRegisterIdentifier { get; set; } = true;

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (RequireRegisterIdentifier && (actionContext.ActionDescriptor.GetCustomAttributes<RegisterAccessAttribute>().Count == 0 || actionContext.ActionDescriptor.GetCustomAttributes<RegisterAccessAttribute>()[0].RequireRegisterIdentifier))
            {
                if (!actionContext.Request.Headers.Contains("RegisterIdentifier") ||
                    !Guid.TryParse(actionContext.Request.Headers.GetValues("RegisterIdentifier").First(), out Guid registerIdentifier))
                {
                    actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                    return;
                }

                RegisterCache.CachedRegister cachedRegister = RegisterCache.GetRegisterByIdentifier(registerIdentifier);

                actionContext.Request.Properties["RegisterIdentifier"] = registerIdentifier;
                actionContext.Request.Properties["CachedRegister"] = cachedRegister;
            }
        }
    }
}
