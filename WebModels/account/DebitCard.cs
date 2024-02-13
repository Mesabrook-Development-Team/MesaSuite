using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using System;
using WebModels.security;

namespace WebModels.account
{
    [Table("5D91FBF2-02B1-4543-8974-B39C83E55D1A")]
    public class DebitCard : DataObject
    {
        protected DebitCard() : base() { }

        private long? _debitCardID;
        [Field("860B0EF5-A191-41CC-A2FA-1AFC5F877CB7")]
        public long? DebitCardID
        {
            get { CheckGet(); return _debitCardID; }
            set { CheckSet(); _debitCardID = value; }
        }

        private long? _accountID;
        [Field("1B6E0D7F-5E9E-4E6C-8E1C-1D2C7C1E0C6C")]
        public long? AccountID
        {
            get { CheckGet(); return _accountID; }
            set { CheckSet(); _accountID = value; }
        }

        private Account _account = null;
        [Relationship("59D297B1-5CBC-4D00-9753-20FC31D37694")]
        public Account Account
        {
            get { CheckGet(); return _account; }
        }

        private string _cardNumber;
        [Field("1520C52C-DF9B-4CF1-A1A8-F1EBEB960418", DataSize = 16)]
        public string CardNumber
        {
            get { CheckGet(); return _cardNumber; }
            set { CheckSet(); _cardNumber = value; }
        }

        private short? _pin;
        [Field("6D0E8F41-7EB5-4B9A-9D9F-5A9E6D4B6E6F")]
        public short? Pin
        {
            get { CheckGet(); return _pin; }
            set { CheckSet(); _pin = value; }
        }

        private DateTime? _issuedTime;
        [Field("E8E6F9E8-3E6C-4A3E-8F8A-7F6B7F6B7F6B", DataSize = 7)]
        public DateTime? IssuedTime
        {
            get { CheckGet(); return _issuedTime; }
            set { CheckSet(); _issuedTime = value; }
        }

        private long? _userIDIssuedBy;
        [Field("E8E6F9E8-3E6C-4A3E-8F8A-7F6B7F6B7F6B")]
        public long? UserIDIssuedBy
        {
            get { CheckGet(); return _userIDIssuedBy; }
            set { CheckSet(); _userIDIssuedBy = value; }
        }

        private User _userIssuedBy = null;
        [Relationship("E8E6F9E8-3E6C-4A3E-8F8A-7F6B7F6B7F6B", ForeignKeyField = nameof(UserIDIssuedBy))]
        public User UserIssuedBy
        {
            get { CheckGet(); return _userIssuedBy; }
        }
    }
}