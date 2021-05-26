using API_User.Cache;
using OAuth.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API_User.Attributes
{
    public class MesabrookAuthorizationAttribute : ActionFilterAttribute
    {
        public async override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(actionContext.Request.Headers.Authorization?.Scheme) ||
                string.IsNullOrEmpty(actionContext.Request.Headers.Authorization.Parameter) ||
                !actionContext.Request.Headers.Authorization.Scheme.Equals("Bearer") ||
                !await SecurityCache.IsValid(actionContext.Request.Headers.Authorization.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            SecurityProfile securityProfile = SecurityCache.Get(actionContext.Request.Headers.Authorization.Parameter);

            if (securityProfile == null || !RequiredPermissions.All(permission => securityProfile.Permissions.Contains(permission)))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }

            actionContext.Request.Properties.Add("SecurityProfile", securityProfile);
        }

        public string[] RequiredPermissions { get; set; } = new string[0];
    }
}