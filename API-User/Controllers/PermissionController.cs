using API_User.Attributes;
using API_User.Models.security;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Extensions;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Validation;
using OAuth.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using WebModels.security;

namespace API_User.Controllers
{
    public class PermissionController : ApiController
    {
        [HttpGet]
        [MesabrookAuthorization]
        public List<string> GetCurrentPermissions()
        {
            SecurityProfile profile = Request.Properties["SecurityProfile"] as SecurityProfile;

            LDAPUser user = DataObject.GetReadOnlyByPrimaryKey<LDAPUser>(profile.UserID, null, new string[] { "UserPermissions.Permission.Key" });
            return user.UserPermissions.Select(up => up.Permission.Key).ToList();
        }

        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ViewUsers" })]
        public List<Permission> GetPermissionKeys()
        {
            return new Search<Permission>().GetReadOnlyReader(null, new string[] { "PermissionID", "Name", "Key" }).ToList();
        }

        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers" })]
        public List<Permission> GetPermissionsForUser(long? userid)
        {
            if (userid == null)
            {
                return null;
            }

            List<string> permissionFields = Schema.GetSchemaObject<Permission>().GetFields().Select(f => $"UserPermissions.Permission." + f.FieldName).ToList();
            LDAPUser user = DataObject.GetReadOnlyByPrimaryKey<LDAPUser>(userid, null, permissionFields);

            return user.UserPermissions.Select(up => up.Permission).ToList();
        }

        [HttpPost]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public IHttpActionResult SetPermissionsForUser(List<UserPermission> userPermissions)
        {
            long? userID = userPermissions.First().UserID;

            if (userPermissions.Any(up => up.UserID != userID))
            {
                return BadRequest("All User IDs must be the same.");
            }

            StringBuilder errorBuilder = new StringBuilder("The following errors occurred:");
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                foreach(UserPermission userPermission in userPermissions)
                {
                    if (!userPermission.Save(transaction))
                    {
                        foreach(Error error in userPermission.Errors)
                        {
                            errorBuilder.AppendLine(error.Message);
                        }
                    }
                }

                transaction.Commit();
            }

            NotifyOAuthServerOfPermissionChanges(userID.Value, "permissions");

            if (userPermissions.Any(up => up.Errors.Any()))
            {
                return BadRequest(errorBuilder.ToString());
            }

            return Ok();
        }

        [HttpDelete]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public IHttpActionResult DeletePermissionForUser(long? userid, long? permissionid)
        {
            Search<UserPermission> userPermissionSearch = new Search<UserPermission>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<UserPermission>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userid
                },
                new LongSearchCondition<UserPermission>()
                {
                    Field = "PermissionID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = permissionid
                }));

            UserPermission dbUserPermission = userPermissionSearch.GetEditable();
            if (!dbUserPermission.Delete())
            {
                StringBuilder errorBuilder = new StringBuilder("The following errors occurred during delete:");
                foreach(Error error in dbUserPermission.Errors)
                {
                    errorBuilder.AppendLine(error.Message);
                }

                return BadRequest(errorBuilder.ToString());
            }

            NotifyOAuthServerOfPermissionChanges(userid.Value, "permissions");

            return Ok();
        }

        internal static void NotifyOAuthServerOfPermissionChanges(long userID, string action)
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

        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public Permission GetPermission(long? permissionid)
        {
            return DataObject.GetEditableByPrimaryKey<Permission>(permissionid, null, Enumerable.Empty<string>());
        }

        [HttpGet]
        [MesabrookAuthorization(RequiredPermissions = new string[] { "User/User/ManageUsers"})]
        public List<LDAPUser> GetUsersForPermission(long? permissionid)
        {
            List<string> fields = Schema.GetSchemaObject<LDAPUser>().GetFields().Select(f => $"UserPermissions.User.{f.FieldName}").ToList();

            Permission permission = DataObject.GetReadOnlyByPrimaryKey<Permission>(permissionid, null, fields);

            return permission?.UserPermissions.Select(up => up.User.As<LDAPUser>().PopulateActiveDirectoryInformation()).ToList();
        }
    }
}
