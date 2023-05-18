using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.security;

namespace WebModels.auth
{
    [Table("D289C356-C767-471F-9F45-D5CD20F98B34")]
    public class UserClient : DataObject
    {
        protected UserClient() : base() { }

        private long? _userClientID;
        [Field("A8D2A81B-89E4-49E9-BE54-65412D9F59D7")]
        public long? UserClientID
        {
            get { CheckGet(); return _userClientID; }
            set { CheckSet(); _userClientID = value; }
        }

        private long? _userID;
        [Field("C4DD283E-94FA-41AC-988C-62FF01BA9DF2")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("54884108-9E5A-4908-873E-924116EFE58F")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private long? _clientID;
        [Field("9EC0D1D5-8E80-4D32-9B90-28D790F36B70")]
        [Required]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
            set { CheckSet(); _clientID = value; }
        }

        private Client _client = null;
        [Relationship("90FD260F-74B8-49CB-A57F-35203A75D768")]
        public Client Client
        {
            get { CheckGet(); return _client; }
        }

        private DateTime? _authorizationTime;
        [Field("33C64873-9EF9-47C5-8B19-C4C87C106A32", DataSize = 7)]
        [Required]
        public DateTime? AuthorizationTime
        {
            get { CheckGet(); return _authorizationTime; }
            set { CheckSet(); _authorizationTime = value; }
        }
    }
}
