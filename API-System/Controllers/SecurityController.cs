using API.Common;
using API.Common.Attributes;
using System.Web.Http;

namespace API_System.Controllers
{
    [AllowedIPsOnly]
    [PresharedAuth]
    public class SecurityController : ApiController
    {
        [HttpPost]
        public void Grant(SecurityProfile profile)
        {
            SecurityCache.AddSecurityProfile(profile);
        }

        [HttpPost]
        public void Revoke(RevokeParameter token)
        {
            SecurityCache.Revoke(token.token);
        }

        public class RevokeParameter
        {
            public string token { get; set; }
        }
    }
}
