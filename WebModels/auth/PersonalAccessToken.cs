using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.security;

namespace WebModels.auth
{
    [Table("95D01964-7203-4F56-BD85-C58CDD9AF5A7")]
    public class PersonalAccessToken : DataObject
    {
        protected PersonalAccessToken() : base() { }

        private long? _personalAccessTokenID;
        [Field("D417D8B5-4569-4F05-842F-F93FFB991AAB")]
        public long? PersonalAccessTokenID
        {
            get { CheckGet(); return _personalAccessTokenID; }
            set { CheckSet(); _personalAccessTokenID = value; }
        }

        private long? _userID;
        [Field("5BC82F75-13BA-45C9-A9FA-9D436E4781D9")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("C1A8E8AD-D5CF-4362-AD7B-5F1B41FFFE4B")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private string _token;
        [Field("E84D2B39-7CD3-49B6-A3F7-0701FCA57FFD", DataSize = 50)]
        public string Token
        {
            get { CheckGet(); return _token; }
            set { CheckSet(); _token = value; }
        }

        private DateTime? _expiration;
        [Field("9011EF78-EF77-4355-B6F9-0E4D993E6ED0", DataSize = 7)]
        public DateTime? Expiration
        {
            get { CheckGet(); return _expiration; }
            set { CheckSet(); _expiration = value; }
        }

        // Grants
        private bool _canRefreshInactivity;
        [Field("62436C68-DA2F-4E1F-9D4A-C8E915841DDA")]
        public bool CanRefreshInactivity
        {
            get { CheckGet(); return _canRefreshInactivity; }
            set { CheckSet(); _canRefreshInactivity = value; }
        }

        private bool _canPerformNetworkPrinting;
        [Field("C00D3770-B4B0-401E-925D-262DAEE4D736")]
        public bool CanPerformNetworkPrinting
        {
            get { CheckGet(); return _canPerformNetworkPrinting; }
            set { CheckSet(); _canPerformNetworkPrinting = value; }
        }
    }
}
