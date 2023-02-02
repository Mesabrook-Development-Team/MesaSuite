using API.Common.Cache;
using System.Linq;
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
        public string[] ProgramKeys { get; set; } = new string[0];
        public ProgramAccessAttribute(string ProgramKey)
        {
            ProgramKeys = new string[] { ProgramKey };
        }

        public ProgramAccessAttribute(string[] programKeys)
        {
            this.ProgramKeys = programKeys;
        }

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (ProgramKeys == null || ProgramKeys.Length == 0) // Likely overriding to be public
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

            if (securityProfile == null || !(await UserHasAtLeastOneProgram(securityProfile.UserID)))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }
        }

        private async Task<bool> UserHasAtLeastOneProgram(long userID)
        {
            foreach(string key in ProgramKeys)
            {
                if (await ProgramCache.UserHasProgram(userID, key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}