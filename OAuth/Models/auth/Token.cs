using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using OAuth.App_Code;
using OAuth.Common;
using OAuth.Models.security;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OAuth.Models.auth
{
    [Table("1F5BACCF-41DC-40E7-B3F3-1896C5D20759")]
    public class Token : DataObject
    {
        private long? _tokenID;
        [Field("EB96B9AF-56B6-44CB-876B-3923A7687472")]
        public long? TokenID
        {
            get { CheckGet(); return _tokenID; }
        }

        private long? _clientID;
        [Field("345CEA11-A22D-4C7B-B87E-8224500B6634")]
        [Required]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
            set { CheckSet(); _clientID = value; }
        }

        private Client _client;
        [Relationship("D80CBEF8-6C4B-4EA7-BD9F-35E45BA2E8E8")]
        public Client Client
        {
            get { CheckGet(); return _client; }
        }

        private Guid? _accessToken;
        [Field("76FD74AB-4D3F-4CEB-8A44-BB6060106A5E")]
        [Required]
        public Guid? AccessToken
        {
            get { CheckGet(); return _accessToken; }
            set { CheckSet(); _accessToken = value; }
        }

        private Guid? _refreshToken;
        [Field("D38A928C-6A1F-4F12-B457-538113DF330B")]
        public Guid? RefreshToken
        {
            get { CheckGet(); return _refreshToken; }
            set { CheckSet(); _refreshToken = value; }
        }

        private DateTime? _expiration;
        [Field("5B94F05E-81D6-44DD-8AE0-F7050BDACAB3")]
        [Required]
        public DateTime? Expiration
        {
            get { CheckGet(); return _expiration; }
            set { CheckSet(); _expiration = value; }
        }

        private DateTime? _revokeTime;
        [Field("B2470CD2-467C-4D3C-856D-4CED73BB0644")]
        public DateTime? RevokeTime
        {
            get { CheckGet(); return _revokeTime; }
            set { CheckSet(); _revokeTime = value; }
        }

        private string _revokeReason;
        [Field("19AF146E-A607-4C2B-9D35-D752DAD8EB8E", DataSize = 100)]
        public string RevokeReason
        {
            get { CheckGet(); return _revokeReason; }
            set { CheckSet(); _revokeReason = value; }
        }

        private bool _refreshTokenUsed = false;
        [Field("DC316673-52CE-46B7-83D8-3E067CFDD766")]
        public bool RefreshTokenUsed
        {
            get { CheckGet(); return _refreshTokenUsed; }
            set { CheckSet(); _refreshTokenUsed = value; }
        }

        private long? _userID;
        [Field("46AAAB2A-65D2-4743-9061-5208F5619E04")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

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
            return base.PostSave(transaction);
        }
    }
}