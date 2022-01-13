using API.Common;
using API.Common.Attributes;
using API_Government.App_Code;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API_Government.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    /// <summary>Ensures user is an official</summary>
    public class GovernmentAccessAttribute : ActionFilterAttribute
    {
        public string[] RequiredPermissions { get; set; }
        public string[] OptionalPermissions { get; set; }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpResponseMessage unauthorizedResponse = await MesabrookAuthorizationAttribute.CheckHeadersForSecurity(actionContext);

            if (unauthorizedResponse != null)
            {
                actionContext.Response = unauthorizedResponse;
                return;
            }

            SecurityProfile securityProfile = SecurityCache.Get(actionContext.Request.Headers.Authorization.Parameter);
            if (securityProfile == null || !actionContext.Request.Headers.Contains("GovernmentID") || !long.TryParse(actionContext.Request.Headers.GetValues("GovernmentID").First(), out long governmentID))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
                return;
            }

            OfficialCache.CachedOfficial cachedOfficial = await OfficialCache.GetCachedOfficial(governmentID, securityProfile.UserID);
            if (cachedOfficial.OfficialID == 0)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
                return;
            }

            if (RequiredPermissions != null)
            {
                if (!RequiredPermissions.All(p => cachedOfficial.Permissions.Contains(p)))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
                    return;
                }
            }
            else if (OptionalPermissions != null)
            {
                if (!OptionalPermissions.Any(p => cachedOfficial.Permissions.Contains(p)))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
                    return;
                }
            }

            base.OnActionExecuting(actionContext);
        }
    }
}