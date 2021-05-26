using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System.Collections.Generic;

namespace OAuth.Models.security
{
    [Table("554BDF2E-ACA5-46AB-A56E-080E6823267F")]
    public class User : DataObject
    {
        private long? _userID;
        [Field("7BD9DFA8-8EC1-4159-AEDF-5A9330AEF3EB")]
        public long? UserID
        {
            get { CheckGet(); return _userID; }
        }

        private string _username;
        [Field("DF59672D-B5FB-43F7-8B42-BFC44097B54E", DataSize = 50)]
        [Required]
        public string Username
        {
            get { CheckGet(); return _username; }
            set { CheckSet(); _username = value; }
        }

        private List<UserPermission> _userPermissions = new List<UserPermission>();
        [RelationshipList("35E5C518-8874-4E92-A544-A0E1E8DDDC2F", "UserID")]
        public IReadOnlyCollection<UserPermission> UserPermissions
        {
            get { CheckGet(); return _userPermissions; }
        }
    }
}