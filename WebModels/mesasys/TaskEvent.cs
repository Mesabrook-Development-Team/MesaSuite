using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;

namespace WebModels.mesasys
{
    [Table("783DF75D-DB95-43FB-B229-FEC2E58E31FD")]
    public class TaskEvent : DataObject
    {
        protected TaskEvent() : base() { }

        private long? _taskEventID;
        [Field("70EC146A-9BE9-4692-8F13-3F7D830E2A54")]
        public long? TaskEventID
        {
            get { CheckGet(); return _taskEventID; }
            set { CheckSet(); _taskEventID = value; }
        }

        private Guid? _systemID;
        [Field("DBA025AA-2C89-41CE-8A4D-7375B6387BB9", IsSystemLoaded = true)]
        [Required]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        private byte[] _systemHash;
        [Field("3E141045-904F-47B7-896C-0EB01899DE26", IsSystemLoaded = true)]
        public byte[] SystemHash
        {
            get { CheckGet(); return _systemHash; }
            set { CheckSet(); _systemHash = value; }
        }

        public enum ScopeTypes
        {
            Global,
            Company,
            Location,
            Government,
            Fleet
        }

        private ScopeTypes _scopeType;
        [Field("5E252EA1-B8B1-4586-8EA2-8AD2F56CB45F", IsSystemLoaded = true)]
        [Required]
        public ScopeTypes ScopeType
        {
            get { CheckGet(); return _scopeType; }
            set { CheckSet(); _scopeType = value; }
        }

        private string _scopePermissions;
        [Field("B1B02A33-F729-48E0-A36D-615D8DB01CBE", DataSize = -1, IsSystemLoaded = true)]
        public string ScopePermissions
        {
            get { CheckGet(); return _scopePermissions; }
            set { CheckSet(); _scopePermissions = value; }
        }

        private string _name;
        [Field("230E8C83-A1AB-4FE8-B816-4B4C321D7C1D", DataSize = 50, IsSystemLoaded = true)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value; }
        }

        #region Relationships
        #region mesasys
        private List<TaskSubscriber> _taskSubscribers = new List<TaskSubscriber>();
        [RelationshipList("8266540F-B6ED-4A6F-895C-4FB2C11CE5B3", nameof(TaskSubscriber.TaskEventID), AutoDeleteReferences = true)]
        public List<TaskSubscriber> TaskSubscribers
        {
            get { CheckGet(); return _taskSubscribers; }
        }
        #endregion
        #endregion
    }
}
