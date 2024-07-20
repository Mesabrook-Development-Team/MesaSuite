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
    public class NotificationSubscriberEntity : DataObject
    {
        protected NotificationSubscriberEntity() : base() { }

        private long? _notificationSubscriberEntityID;
        [Field("07DE9825-9599-4453-ACD0-931B0664D61E")]
        public long? NotificationSubscriberEntityID
        {
            get { CheckGet(); return _notificationSubscriberEntityID; }
            set { CheckSet(); _notificationSubscriberEntityID = value; }
        }

        private long? _notificationSubscriberID;
        [Field("AAA90AED-D1AB-4486-882C-24271D14CE81")]
        [Required]
        public long? NotificationSubscriberID
        {
            get { CheckGet(); return _notificationSubscriberID; }
            set { CheckSet(); _notificationSubscriberID = value; }
        }

        private NotificationSubscriber _notificationSubscriber = null;
        [Relationship("9C01184C-8261-4DC7-A039-57A774AC3B52")]
        public NotificationSubscriber NotificationSubscriber
        {
            get { CheckGet(); return _notificationSubscriber; }
        }

        private long? _companyID;
        [Field("D15EA093-8935-4523-9CA6-397BE880DB0F")]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("40681CA4-1B85-4D67-887E-9C37A01A1245")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private long? _locationID;
        [Field("0CF4CC93-4CB8-4347-9594-41F93EF5804A")]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private Location _location = null;
        [Relationship("E0A7B0EE-DC7B-410A-BD71-432EF7D1F862")]
        public Location Location
        {
            get { CheckGet(); return _location; }
        }

        private long? _governmentID;
        [Field("C831203C-8839-46EB-8FA0-8ED701F2166B")]
        public long? GovernmentID
        {
            get { CheckGet(); return _governmentID; }
            set { CheckSet(); _governmentID = value; }
        }

        private Government _government = null;
        [Relationship("BE9FBBF7-E149-462A-BB4F-065C5DF71B5C")]
        public Government Government
        {
            get { CheckGet(); return _government; }
        }
    }
}
