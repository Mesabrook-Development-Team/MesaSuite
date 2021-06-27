using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;

namespace WebModels.security
{
    [Table("D2956313-9B89-4093-8DB6-0F5EC9C42088")]
    public class Permission : DataObject, ISystemLoaded
    {
        protected Permission() : base() { }

        private long? _permissionID = null;
        [Field("92A4B914-2B52-44DD-AB51-66A5DAF73D50")]
        public long? PermissionID
        {
            get { CheckGet(); return _permissionID; }
        }

        private string _name;
        [Field("6B926A96-7522-4410-9C0A-713982DF66B1", DataSize = 100, IsSystemLoaded = true)]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private string _key;
        [Field("26BE4F84-CC5E-45FD-859D-6B999BD896FF", DataSize = 50, IsSystemLoaded = true)]
        [Required]
        public string Key
        {
            get { CheckGet(); return _key; }
            set { CheckSet(); _key = value; }
        }

        private Guid? _systemID;
        [Field("6428F736-81F6-4BD9-8C27-92DFAE7891E7")]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        private byte[] _systemHash;
        [Field("DA8D8928-FAC5-4F4B-96F0-B239E8B7135A")]
        public byte[] SystemHash
        {
            get { CheckGet(); return _systemHash; }
            set { CheckSet(); _systemHash = value; }
        }

        #region Relationships
        private List<UserPermission> _userPermissions = new List<UserPermission>();
        [RelationshipList("50FA28F1-ED25-427D-A42E-F4FA40D1A0B6", "PermissionID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<UserPermission> UserPermissions
        {
            get { CheckGet(); return _userPermissions; }
        }
        #endregion
    }
}