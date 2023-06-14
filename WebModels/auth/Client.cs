using ClussPro.Base.Data;
using ClussPro.Base.Data.Conditions;
using ClussPro.Base.Data.Operand;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using WebModels.security;

namespace WebModels.auth
{
    [Table("58DB9C4D-6F68-4A00-A675-E48D86EB97DA")]
    [Unique(new string[] { "ClientIdentifier" })]
    public class Client : DataObject
    {
        protected Client() : base() { }

        private long? _clientID;
        [Field("A8124915-DD2A-4180-8F2E-59CC210A5250")]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
            set { CheckSet(); _clientID = value; }
        }

        private Guid? _clientIdentifier;
        [Field("DF81C32E-1B7F-44DE-86E4-8EEA963E46E3")]
        [Required]
        public Guid? ClientIdentifier
        {
            get { CheckGet(); return _clientIdentifier; }
            set { CheckSet(); _clientIdentifier = value; }
        }

        private string _redirectionURI;
        [Field("D5853DEC-73E4-402C-8DEA-5702D5A21405", DataSize = 500)]
        public string RedirectionURI
        {
            get { CheckGet(); return _redirectionURI; }
            set { CheckSet(); _redirectionURI = value; }
        }

        public enum Types
        {
            BrowserEnabled,
            Device
        }

        private Types _type = Types.BrowserEnabled;
        [Field("F187C02F-7230-4E21-975E-94AF49093176")]
        public Types Type
        {
            get { CheckGet(); return _type; }
            set { CheckSet(); _type = value; }
        }

        private string _clientName;
        [Field("C34DCD25-D887-4FFF-B5A0-23487DB0B4FE", DataSize = 50)]
        public string ClientName
        {
            get { CheckGet(); return _clientName; }
            set { CheckSet(); _clientName = value; }
        }

        private long? _userID;
        [Field("67923050-3E72-4741-877E-19BA71D36072")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user;
        [Relationship("3FBE7C80-54E4-4FAC-BF9A-19EDEBF5DEA2")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private int _userCount;
        [Field("5EA0B7B2-712A-4CF8-B085-6004305D76CA", HasOperation = true)]
        public int UserCount
        {
            get { CheckGet(); return _userCount; }
        }

        public static OperationDelegate UserCountOperation
        {
            get
            {
                return (alias) =>
                {
                    ISelectQuery select = SQLProviderFactory.GetSelectQuery();
                    select.Table = new Table("auth", "UserClient", "ucCount");
                    select.SelectList = new List<Select>()
                    {
                        new Select() { SelectOperand = new Count((Field)"ucCount.UserClientID") }
                    };
                    select.WhereCondition = new Condition()
                    {
                        Left = (Field)"ucCount.ClientID",
                        ConditionType = Condition.ConditionTypes.Equal,
                        Right = (Field)$"{alias}.ClientID"
                    };

                    return new SubQuery(select);
                };
            }
        }

        protected override void PreValidate()
        {
            if (IsInsert)
            {
                ClientIdentifier = Guid.NewGuid();
            }

            base.PreValidate();
        }

        #region Relationships
        private List<UserClient> _userClients = new List<UserClient>();
        [RelationshipList("1A40012B-9FEB-407C-B779-97C5E34202AE", nameof(UserClient.ClientID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<UserClient> UserClients
        {
            get { CheckGet(); return _userClients; }
        }

        private List<Token> _tokens = new List<Token>();
        [RelationshipList("F9111B34-F4D4-497E-ACCE-A3870EAF7B42", "ClientID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<Token> Tokens
        {
            get { CheckGet(); return _tokens; }
        }

        private List<DeviceCode> _deviceCodes = new List<DeviceCode>();
        [RelationshipList("CD2C721D-B72A-48FF-8568-9527DEF3DA5D", nameof(DeviceCode.ClientID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<DeviceCode> DeviceCodes
        {
            get { CheckGet(); return _deviceCodes; }
        }
        #endregion

        public bool ContainsRedirectURI(string redirectURI)
        {
            string[] redirectionUris = RedirectionURI.Split(';');

            return redirectionUris.Contains(redirectURI);
        }
    }
}