using API_User.Attributes;
using API_User.Extensions;
using API_User.Models;
using API_User.Models.security;
using ClussPro.Base.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace API_User.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ViewUsers"} )]
        public List<LDAPUser> GetAllUsers()
        {
            return new Search<LDAPUser>().GetReadOnlyReader(null, new string[] { "UserID", "Username" }).ForEach(u => u.PopulateActiveDirectoryInformation()).ToList();
        }

        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers" })]
        public LDAPUser GetUser(long? userid)
        {
            if (userid == null)
            {
                return null;
            }

            return DataObject.GetEditableByPrimaryKey<LDAPUser>(userid, null, Enumerable.Empty<string>()).PopulateActiveDirectoryInformation();
        }

        [HttpPut]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public IHttpActionResult UpdateUser(LDAPUser user)
        {
            if (user.UserID == null || user.UserID == 0)
            {
                return NotFound();
            }

            LDAPUser dbUser = DataObject.GetEditableByPrimaryKey<LDAPUser>(user.UserID, null, Enumerable.Empty<string>())?.PopulateActiveDirectoryInformation();
            user.Copy(dbUser);
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;
            dbUser.MemberOf = user.MemberOf ?? dbUser.MemberOf;

            if (!dbUser.Save())
            {
                StringBuilder errors = new StringBuilder("The following validation errors occurred:");
                foreach(Error error in dbUser.Errors)
                {
                    errors.AppendLine(error.Message);
                }

                return BadRequest(errors.ToString());
            }

            dbUser.UpdateActiveDirectoryInformation();

            return Ok(dbUser);
        }

        [HttpPost]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers" })]
        public IHttpActionResult PostUserExisting(LDAPUser user)
        {
            if (user.UserID != null && user.UserID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!user.Save())
            {
                StringBuilder errors = new StringBuilder("The following validation errors occurred:");
                foreach (Error error in user.Errors)
                {
                    errors.AppendLine(error.Message);
                }

                return BadRequest(errors.ToString());
            }

            user.PopulateActiveDirectoryInformation().UpdateActiveDirectoryInformation();

            return Created("GetUser?userid=" + user.UserID, user);
        }

        [HttpPost]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public IHttpActionResult PostUserNew(LDAPUser user)
        {
            if (user.UserID != null && user.UserID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!user.Save())
            {
                StringBuilder errors = new StringBuilder("The following validation errors occurred:");
                foreach (Error error in user.Errors)
                {
                    errors.AppendLine(error.Message);
                }

                return BadRequest(errors.ToString());
            }

            user.CreateActiveDirectoryUser();

            return Created("GetUser?userid=" + user.UserID, user);
        }

        [HttpDelete]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public IHttpActionResult DeleteUser(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LDAPUser user = DataObject.GetEditableByPrimaryKey<LDAPUser>(id, null, Enumerable.Empty<string>()).PopulateActiveDirectoryInformation();
            if (!user.Delete())
            {
                StringBuilder errorText = new StringBuilder("One or more errors ocurred during delete:");

                foreach(Error error in user.Errors)
                {
                    errorText.AppendLine(error.Message);
                }

                return BadRequest(errorText.ToString());
            }
            user.DisableActiveDirectoryUser();

            PermissionController.NotifyOAuthServerOfPermissionChanges(id.Value, "userhasbeendeleted");

            return Ok();
        }

        [HttpPatch]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public IHttpActionResult PatchUser(PatchData patchData)
        {
            LDAPUser user = DataObject.GetEditableByPrimaryKey<LDAPUser>(patchData.PrimaryKey, null, Enumerable.Empty<string>())?.PopulateActiveDirectoryInformation();
            if (user == null)
            {
                return NotFound();
            }

            user.PatchData(patchData.Method, patchData.Values);

            if (!user.Save())
            {
                return BadRequest();
            }

            user.UpdateActiveDirectoryInformation();

            return Ok();
        }
    }
}
