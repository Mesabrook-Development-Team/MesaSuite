using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using OAuth.App_Code;
using API.Common;
using System.Linq;
using WebModels.auth;
using WebModels.security;

namespace OAuth.Models.auth
{
    public class OAuthToken : Token
    {
        protected OAuthToken() : base() { }

        protected override bool PostSave(ITransaction transaction)
        {
            if (IsInsert && RevokeTime == null) // Is insert, not revoking
            {
                SecurityProfile securityProfile = new SecurityProfile();
                securityProfile.AccessToken = AccessToken.ToString();
                securityProfile.Expiration = Expiration.Value;
                securityProfile.UserID = UserID.Value;

                App_Code.SecurityCache.AddSecurityProfile(securityProfile);
            }

            if (IsFieldDirty("RevokeTime") && RevokeTime != null)
            {
                App_Code.SecurityCache.Revoke(AccessToken.ToString());
            }

            return true;
        }
    }
}