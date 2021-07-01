using API_System.Cache;
using OAuth.Common;
using OAuth.Common.Attributes;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API_System.Attributes
{
    public class ProgramAccessAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            HttpResponseMessage unauthorizedResponse = await MesabrookAuthorizationAttribute.CheckHeadersForSecurity(actionContext);

            if (unauthorizedResponse != null)
            {
                actionContext.Response = unauthorizedResponse;
                return;
            }

            SecurityProfile securityProfile = SecurityCache.Get(actionContext.Request.Headers.Authorization.Parameter);

            if (securityProfile == null || !await ProgramCache.UserHasProgram(securityProfile.UserID, "system"))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
    }
}