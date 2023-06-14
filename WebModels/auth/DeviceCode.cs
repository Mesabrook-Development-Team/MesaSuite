using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.auth
{
    [Table("D46B82F6-D51A-4F91-BD09-B45D8670861D")]
    public class DeviceCode : DataObject
    {
        protected DeviceCode() : base() { }

        private long? _deviceCodeID;
        [Field("61039CA3-2C81-46E3-9CE3-E6B9D07C0C96")]
        public long? DeviceCodeID
        {
            get { CheckGet(); return _deviceCodeID; }
            set { CheckSet(); _deviceCodeID = value; }
        }

        private long? _clientID;
        [Field("B2C66D32-91FC-4877-8DB2-140C2176DCEA")]
        [Required]
        public long? ClientID
        {
            get { CheckGet(); return _clientID; }
            set { CheckSet(); _clientID = value; }
        }

        private Client _client = null;
        [Relationship("3AE76E49-C6E5-490C-B3C5-2AC4F3C131F5")]
        public Client Client
        {
            get { CheckGet(); return _client; }
        }

        private string _deviceCodeString;
        [Field("71328A4C-FE63-4606-892B-BCA3118905FA", DataSize = 16)]
        [Required]
        public string DeviceCodeString
        {
            get { CheckGet(); return _deviceCodeString; }
            set { CheckSet(); _deviceCodeString = value; }
        }

        private string _userCode;
        [Field("4DBEA251-9FE1-4A87-BD19-98083C845EC6", DataSize = 5)]
        [Required]
        public string UserCode
        {
            get { CheckGet(); return _userCode; }
            set { CheckSet(); _userCode = value; }
        }

        private DateTime? _lastPing;
        [Field("5E440F82-3185-44E0-AEF0-437224764844", DataSize = 7)]
        public DateTime? LastPing
        {
            get { CheckGet(); return _lastPing; }
            set { CheckSet(); _lastPing = value; }
        }

        public enum Statuses
        {
            WaitingOnUser,
            Accepted,
            Rejected
        }

        private Statuses _status;
        [Field("2520CB5E-C6F2-427F-B2B5-CC209A7B54A4")]
        public Statuses Status
        {
            get { CheckGet(); return _status; }
            set { CheckSet(); _status = value; }
        }

        private long? _codeID;
        [Field("0FDDF60F-A31F-4906-951D-4F241F2D322E")]
        public long? CodeID
        {
            get { CheckGet(); return _codeID; }
            set { CheckSet(); _codeID = value; }
        }

        private Code _code = null;
        [Relationship("EBFA6DE1-7243-462C-992C-080EBE84CF56")]
        public Code Code
        {
            get { CheckGet(); return _code; }
        }
    }
}
