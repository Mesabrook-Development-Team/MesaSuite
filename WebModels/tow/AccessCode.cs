using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.security;

namespace WebModels.tow
{
    [Table("D943F14C-0E21-420D-8887-53F5EC5CF1EC")]
    public class AccessCode : DataObject
    {
        protected AccessCode() : base() { }

        private long? _accessCodeID;
        [Field("9766DC8E-A1A2-430C-9C42-FB3BE17FA915")]
        public long? AccessCodeID
        {
            get { CheckGet(); return _accessCodeID; }
            set { CheckSet(); _accessCodeID = value; }
        }

        private long? _towTicketID;
        [Field("C82B337D-316F-4D90-B2B7-41E6B3090893")]
        public long? TowTicketID
        {
            get { CheckGet(); return _towTicketID; }
            set { CheckSet(); _towTicketID = value; }
        }

        private TowTicket _towTicket = null;
        [Relationship("0AE9F8EF-90B6-49F8-8AB4-8037CDAF7683")]
        public TowTicket TowTicket
        {
            get { CheckGet(); return _towTicket; }
        }

        private long? _userID;
        [Field("1CE51879-7A26-4EC7-B6EF-E41E24279726")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user;
        [Relationship("12F3A0D0-A94C-4696-A16D-7080B8B86BB6")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private string _code;
        [Field("6A805905-F7A4-43EC-BF51-91B17B08826D", DataSize = 4)]
        public string Code
        {
            get { CheckGet(); return _code; }
            set { CheckSet(); _code = value; }
        }
    }
}
