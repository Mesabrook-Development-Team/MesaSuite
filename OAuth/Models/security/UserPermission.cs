using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace OAuth.Models.security
{
    [Table("16AD589B-7F88-4387-8CB4-DE6369D9E2FD")]
    public class UserPermission : DataObject
    {
        private long? _userPermissionID = null;
        [Field("10E94E9D-1A11-4324-8116-C3F7F038B340")]
        public long? UserPermissionID
        {
            get { CheckGet(); return _userPermissionID; }
        }

        private long? _userID;
        [Field("6B81D1B5-C689-42D4-90D1-D13E3E6D5F61")]
        [Required]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
            set { CheckSet(); _userID = value; }
        }

        private User _user = null;
        [Relationship("02941817-CDA0-4DBF-AF1A-885093FC6BD2")]
        public User User
        {
            get { CheckGet(); return _user; }
        }

        private long? _permissionID;
        [Field("FE46A685-BB3C-437E-BDB9-E31057A92E51")]
        [Required]
        public long? PermissionID
        {
            get { CheckGet(); return _permissionID; }
            set { CheckSet(); _permissionID = value; }
        }

        private Permission _permission = null;
        [Relationship("BFDC8ED1-2D0A-4F2A-BA5B-DFEFA74884B3")]
        public Permission Permission
        {
            get { CheckGet(); return _permission; }
        }
    }
}