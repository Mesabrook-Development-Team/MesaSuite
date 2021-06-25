using API_User.Attributes;
using System.Collections.Generic;
using System.Web.Http;

namespace API_User.Controllers
{
    public class ActiveDirectoryGroupController : ApiController
    {
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public List<string> GetGroups()
        {
            return Models.security.LDAPUser.GetAllActiveDirectoryGroups();
        }
    }
}
