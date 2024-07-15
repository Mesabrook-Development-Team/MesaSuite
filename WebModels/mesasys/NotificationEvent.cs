using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebModels.mesasys
{
    [Table("EE1A6909-267A-4E8B-A495-14CA8A31BA75")]
    public class NotificationEvent : DataObject
    {
        protected NotificationEvent() : base() { }

        private long? _notificationEventID;
        [Field("19F7C5C5-FB0F-422C-9307-9FC4F700D849")]
        public long? NotificationEventID
        {
            get { CheckGet(); return _notificationEventID; }
            set { CheckSet(); _notificationEventID = value; }
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
        [Field("B7B6D786-55B7-43E4-9432-D9AF6F045259", IsSystemLoaded = true)]
        [Required]
        public ScopeTypes ScopeType
        {
            get { CheckGet(); return _scopeType; }
            set { CheckSet(); _scopeType = value; }
        }

        private string _scopePermissions;
        [Field("AC02D1C9-B244-40A8-AE2B-1C1B65356FA2", DataSize = -1, IsSystemLoaded = true)]
        [Required]
        public string ScopePermissions
        {
            get { CheckGet(); return _scopePermissions; }
            set { CheckSet(); _scopePermissions = value; }
        }

        private bool _isPublished = false;
        [Field("975F799F-D63A-4CC8-A7AA-3454566B7F17")]
        public bool IsPublished
        {
            get { CheckGet(); return _isPublished; }
            set { CheckSet(); _isPublished = value; }
        }

        private string _parameters;
        [Field("C793EDD0-DA0B-4BE6-927B-ABC7DCF34EC9", DataSize = -1, IsSystemLoaded = true)]
        public string Parameters
        {
            get { CheckGet(); return _parameters; }
            set { CheckSet(); _parameters = value; }
        }

        private long? _userIDOwner;
        [Field("10207268-9D28-4086-8D36-0397A8FACE72")]
        public long? UserIDOwner
        {
            get { CheckGet(); return _userIDOwner; }
            set { CheckSet(); _userIDOwner = value; }
        }

        private Guid? _userSecret;
        [Field("A4112B6D-E21A-4829-8979-0D5C09404342")]
        public Guid? UserSecret
        {
            get { CheckGet(); return _userSecret; }
            set { CheckSet(); _userSecret = value; }
        }

        private Guid? _systemID;
        [Field("3A09F1BF-41D6-4E14-80AD-856901236705", IsSystemLoaded = true)]
        public Guid? SystemID
        {
            get { CheckGet(); return _systemID; }
            set { CheckSet(); _systemID = value; }
        }

        #region Relationships
        #region mesasys
        private List<NotificationSubscriber> _notificationSubscribers = new List<NotificationSubscriber>();
        [RelationshipList("837364D5-4380-4462-82F6-45CF27F96689", nameof(NotificationSubscriber.NotificationEventID))]
        public IReadOnlyCollection<NotificationSubscriber> NotificationSubscribers
        {
            get { CheckGet(); return _notificationSubscribers; }
        }
        #endregion
        #endregion
    }
}
