using API.Common.Attributes;
using System.Web.Http;

namespace API.Common.Controllers
{
    [AllowedIPsOnly]
    [PresharedAuth]
    /// <summary>Handles incoming authentication updates</summary>
    public abstract class BaseSecurityController : ApiController
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
