using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_System.Models.security;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;

namespace API_System.Controllers
{
    [ProgramAccess("system")]
    [MesabrookAuthorization]
    public class UserController : ApiController
    {
        [HttpGet]
        public List<LDAPUser> GetAllUsers()
        {
            return new Search<LDAPUser>().GetReadOnlyReader(null, new string[] { "UserID", "Username" }).ForEach(u => u.PopulateActiveDirectoryInformation()).ToList();
        }

        [HttpGet]
        public LDAPUser GetUser(long? userid)
        {
            if (userid == null)
            {
                return null;
            }

            return DataObject.GetEditableByPrimaryKey<LDAPUser>(userid, null, Enumerable.Empty<string>()).PopulateActiveDirectoryInformation();
        }

        [HttpGet]
        public List<LDAPUser> GetUsers([FromUri] long[] userids)
        {
            if (!userids.Any())
            {
                return new List<LDAPUser>();
            }

            Search<LDAPUser> userSearch = new Search<LDAPUser>(new LongSearchCondition<LDAPUser>()
            {
                Field = "UserID",
                SearchConditionType = SearchCondition.SearchConditionTypes.List,
                List = userids.ToList()
            });

            List<string> fields = Schema.GetSchemaObject<LDAPUser>().GetFields().Select(f => f.FieldName).ToList();
            return userSearch.GetReadOnlyReader(null, fields).ToList();
        }

        [HttpPut]
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
        public IHttpActionResult PostUserNew(LDAPUser user)
        {
            if (user.UserID != null && user.UserID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!user.Save())
            {
                return user.HandleFailedValidation(this);
            }

            user.CreateActiveDirectoryUser();

            return Created("GetUser?userid=" + user.UserID, user);
        }

        [HttpDelete]
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

            NotifyOAuthServerOfProgramChanges(id.Value, "userhasbeendeleted");

            return Ok();
        }

        [HttpPatch]
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

        internal static void NotifyOAuthServerOfProgramChanges(long userID, string action)
        {
            string user = ConfigurationManager.AppSettings.Get("OAuthUser");
            string password = ConfigurationManager.AppSettings.Get("OAuthPass");
            byte[] userPasswordBytes = Encoding.UTF8.GetBytes(user + ":" + password);
            string userPassword = Convert.ToBase64String(userPasswordBytes);

            HttpWebRequest request = WebRequest.CreateHttp(ConfigurationManager.AppSettings.Get("OAuthHost") + "/check/" + action);
            request.Method = WebRequestMethods.Http.Post;
            request.Headers.Add("Authorization", "Basic " + userPassword);
            request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.WriteLine("userid=" + userID);
            }

            request.GetResponseAsync();
        }
    }
}
