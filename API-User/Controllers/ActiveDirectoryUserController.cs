using API_User.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace API_User.Controllers
{
    public class ActiveDirectoryUserController : ApiController
    {
        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers" })]
        public List<string> GetAllActiveDirectoryUsers()
        {
            return Models.security.User.GetAllActiveDirectoryUsers();
        }
    }
}
