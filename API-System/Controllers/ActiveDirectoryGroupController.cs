using API_System.Attributes;
using OAuth.Common.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace API_System.Controllers
{
    [ProgramAccess]
    public class ActiveDirectoryGroupController : ApiController
    {
        [MesabrookAuthorization]
        public List<string> GetGroups()
        {
            return Models.security.LDAPUser.GetAllActiveDirectoryGroups();
        }
    }
}
