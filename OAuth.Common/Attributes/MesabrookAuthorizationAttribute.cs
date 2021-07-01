using OAuth.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OAuth.Common.Attributes
{
    public class MesabrookAuthorizationAttribute : ActionFilterAttribute
    {
        public async override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpResponseMessage unauthorizedResponse = await CheckHeadersForSecurity(actionContext);

            if (unauthorizedResponse != null)
            {
                actionContext.Response = unauthorizedResponse;
                return;
            }

            SecurityProfile securityProfile = SecurityCache.Get(actionContext.Request.Headers.Authorization.Parameter);

            if (securityProfile == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }

            actionContext.Request.Properties.Add("SecurityProfile", securityProfile);
        }

        public async static Task<HttpResponseMessage> CheckHeadersForSecurity(HttpActionContext actionContext)
        {
            if (string.IsNullOrEmpty(actionContext.Request.Headers.Authorization?.Scheme) ||
                string.IsNullOrEmpty(actionContext.Request.Headers.Authorization.Parameter) ||
                !actionContext.Request.Headers.Authorization.Scheme.Equals("Bearer") ||
                !await SecurityCache.IsValid(actionContext.Request.Headers.Authorization.Parameter))
            {
                return actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

            return null;
        }
    }
}