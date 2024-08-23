using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebModels.company;
using WebModels.gov;

namespace WebModels.mesasys
{
    [Table("533EAD4C-1387-4A0F-8CA9-85BC9AF747C1")]
    public class NotificationEventEntity : DataObject
    {
        protected NotificationEventEntity() : base() { }

        private long? _notificationEventEntityID;
        [Field("D4A0902D-4F7C-4E66-9E50-03C445234696")]
        public long? NotificationEventEntityID
        {
            get { CheckGet(); return _notificationEventEntityID; }
            set { CheckSet(); _notificationEventEntityID = value; }
        }

        private long? _notificationEventID;
        [Field("E1626079-1096-44C1-9FAE-AD2CD2BA2347")]
        [Required]
        public long? NotificationEventID
        {
            get { CheckGet(); return _notificationEventID; }
            set { CheckSet(); _notificationEventID = value; }
        }

        private NotificationEvent _notificationEvent = null;
        [Relationship("B3DA2D77-4595-4CCD-9A99-2CC1CA13C9F7")]
        public NotificationEvent NotificationEvent
        {
            get { CheckGet(); return _notificationEvent; }
        }

        private long? _companyID;
        [Field("486E5937-0CCC-4514-9F86-26DBF1167A8B")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("A16D3BDA-7F8B-4F2C-A8F8-FA5F4A1B3908")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _locationID;
        [Field("1231593D-D5F7-4145-92BF-848E44250BD3")]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("CEA57D42-C10A-4153-9241-8234E61F1A27")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private long? _governmentID;
        [Field("DCE8D1C6-60D1-4D27-B238-4523D9D021EC")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("847A3BD4-574B-4545-9C3D-B7976CBA90B3")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }
    }
}
