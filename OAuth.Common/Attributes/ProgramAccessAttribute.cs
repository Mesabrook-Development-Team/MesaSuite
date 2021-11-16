using API.Common.Cache;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace API.Common.Attributes
{
    public class ProgramAccessAttribute : ActionFilterAttribute
    {
        public string ProgramKey { get; set; }
        public ProgramAccessAttribute(string ProgramKey)
        {
            this.ProgramKey = ProgramKey;
        }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(ProgramKey)) // Likely overriding to be public
            {
                return;
            }

            HttpResponseMessage unauthorizedResponse = await MesabrookAuthorizationAttribute.CheckHeadersForSecurity(actionContext);

            if (unauthorizedResponse != null)
            {
                actionContext.Response = unauthorizedResponse;
                return;
            }

            SecurityProfile securityProfile = SecurityCache.Get(actionContext.Request.Headers.Authorization.Parameter);

            if (securityProfile == null || !await ProgramCache.UserHasProgram(securityProfile.UserID, ProgramKey))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }
    }
}