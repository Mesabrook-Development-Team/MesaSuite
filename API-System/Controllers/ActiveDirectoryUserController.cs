using API_System.Attributes;
using OAuth.Common.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace API_System.Controllers
{
    [ProgramAccess]
    public class ActiveDirectoryUserController : ApiController
    {
        [HttpGet]
        [MesabrookAuthorization]
        public List<string> GetAllActiveDirectoryUsers()
        {
            return Models.security.LDAPUser.GetAllActiveDirectoryUsers();
        }
    }
}
