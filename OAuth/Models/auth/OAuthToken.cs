using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using OAuth.App_Code;
using OAuth.Common;
using System.Linq;
using WebModels.auth;
using WebModels.security;

namespace OAuth.Models.auth
{
    public class OAuthToken : Token
    {
        protected override bool PostSave(ITransaction transaction)
        {
            if (IsInsert && RevokeTime == null) // Is insert, not revoking
            {
                SecurityProfile securityProfile = new SecurityProfile();
                securityProfile.AccessToken = AccessToken.ToString();
                securityProfile.Expiration = Expiration.Value;
                securityProfile.UserID = UserID.Value;

                User user = DataObject.GetReadOnlyByPrimaryKey<User>(UserID, transaction, new string[] { "UserPermissions.Permission.Key" });
                securityProfile.Permissions.AddRange(user.UserPermissions.Select(up => up.Permission.Key));

                SecurityCache.AddSecurityProfile(securityProfile);
            }

            if (IsFieldDirty("RevokeTime") && RevokeTime != null)
            {
                SecurityCache.Revoke(AccessToken.ToString());
            }

            return true;
        }
    }
}