using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;

namespace WebModels.security
{
    [Table("4F80C5B4-76AA-40FD-8764-A420A44F3381")]
    public class Program : DataObject, ISystemLoaded
    {
        protected Program() : base() { }

        private long? _programID = null;
        [Field("440EC9CF-4390-4D76-AC41-5F5C091270C2")]
        public long? ProgramID
        {
            get { CheckGet(); return _programID; }
            set { CheckSet(); _programID = value; }
        }

        private string _key;
        [Field("F9B917F9-2AD5-423C-A01A-438571C2FB1A", DataSize = 50, IsSystemLoaded = true)]
        public string Key
        {
            get { CheckGet(); return _key; }
            set { CheckSet(); _key = value; }
        }

        private string _name;
        [Field("6395258A-5B4F-4548-96F4-77DE178A7708", DataSize = 100, IsSystemLoaded = true)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        private Guid? _systemID;
        [Field("C15F3E03-371B-4F6A-9FDB-37D621F3EA53")]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        private byte[] _systemHash;
        [Field("B8E729CC-E9D3-4F55-8188-DABCFE9675DB")]
        public byte[] SystemHash
        {
            get { CheckGet(); return _systemHash; }
            set { CheckSet(); _systemHash = value; }
        }

        #region Relationships
        #region security
        private List<UserProgram> _userPrograms = new List<UserProgram>();
        [RelationshipList("FFE763B0-8E08-40D7-AABB-9DF1E1D3DE2C", "ProgramID", AutoDeleteReferences = true)]
        public IReadOnlyCollection<UserProgram> UserPrograms
        {
            get { CheckGet(); return _userPrograms; }
        }
        #endregion
        #endregion
    }
}
