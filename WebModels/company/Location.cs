using System.Collections.Generic;
using System.Linq;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using WebModels.account;
using WebModels.fleet;
using WebModels.invoicing;
using WebModels.mesasys;

namespace WebModels.company
{
    [Table("A3A28E39-0FA0-423C-B6D4-43F2802ED19D")]
    [Unique(new [] { nameof(CompanyID), nameof(Name) })]
    public class Location : DataObject
    {
        protected Location() : base() { }

        private long? _locationID;
        [Field("BC041BDE-50B5-4D80-8081-9A06C79BFA65")]
        public long? LocationID
        {
            get { CheckGet(); return _locationID; }
            set { CheckSet(); _locationID = value; }
        }

        private long? _companyID;
        [Field("0254C75D-C356-45C0-AB7A-A68C75D8B42F")]
        [Required]
        public long? CompanyID
        {
            get { CheckGet(); return _companyID; }
            set { CheckSet(); _companyID = value; }
        }

        private Company _company = null;
        [Relationship("45F492F3-A94B-46DD-9D2C-7DEE83652741")]
        public Company Company
        {
            get { CheckGet(); return _company; }
        }

        private string _name;
        [Field("1FB1B286-C72B-462A-ABD4-E149EF13BCC4", DataSize = 50)]
        [Required]
        public string Name
        {
            get { CheckGet(); return _name; }
            set { CheckSet(); _name = value;}
        }

        private string _invoiceNumberPrefix;
        [Field("FC1EE2D9-48EA-4F74-88FE-A0559D2D60E0", DataSize = 3)]
        public string InvoiceNumberPrefix
        {
            get { CheckGet(); return _invoiceNumberPrefix; }
            set { CheckSet(); _invoiceNumberPrefix = value; }
        }

        private string _nextInvoiceNumber;
        [Field("C3BB92AA-9EEC-4B80-8116-9CDD43B558EC", DataSize = 8)]
        public string NextInvoiceNumber
        {
            get { CheckGet(); return _nextInvoiceNumber; }
            set { CheckSet(); _nextInvoiceNumber = value; }
        }

        private long? _accountIDStoreRevenue;
        [Field("55022849-0C01-4BDC-9023-DA46E19EB696")]
        public long? AccountIDStoreRevenue
        {
            get { CheckGet(); return _accountIDStoreRevenue; }
            set { CheckSet(); _accountIDStoreRevenue = value; }
        }

        private Account _accountStoreRevenue = null;
        [Relationship("77075B0F-D43C-4417-8262-C76481901811", ForeignKeyField = nameof(AccountIDStoreRevenue))]
        public Account AccountStoreRevenue
        {
            get { CheckGet(); return _accountStoreRevenue; }
        }

        private StorePricingAutomation _storePricingAutomation = null;
        [Relationship("99239E57-9024-4226-96F5-BD3B976C1701", OneToOneByForeignKey = true)]
        public StorePricingAutomation StorePricingAutomation
        {
            get { CheckGet(); return _storePricingAutomation; }
        }

        #region Relationships
        #region company
        private List<LocationEmployee> _locationEmployees = new List<LocationEmployee>();
        [RelationshipList("04569132-78B1-42E6-BD47-5729B5B392ED", "LocationID", AutoRemoveReferences = true)]
        public IReadOnlyCollection<LocationEmployee> LocationEmployees
        {
            get { CheckGet(); return _locationEmployees; }
        }

        private List<LocationGovernment> _locationGovernments = new List<LocationGovernment>();
        [RelationshipList("5C8358F5-676C-468E-A745-EBAF6754C67E", "LocationID", AutoRemoveReferences = true)]
        public IReadOnlyCollection<LocationGovernment> LocationGovernments
        {
            get { CheckGet(); return _locationGovernments; }
        }

        private List<Register> _registers = new List<Register>();
        [RelationshipList("56573B92-10FB-4ACF-BFB4-3B6B167D904B", nameof(Register.LocationID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<Register> Registers
        {
            get { CheckGet(); return _registers; }
        }

        private List<LocationItem> _locationItems = new List<LocationItem>();
        [RelationshipList("9BA0848D-68DC-4A88-ADFE-E782D15AEC77", nameof(LocationItem.LocationID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<LocationItem> LocationItems
        {
            get { CheckGet(); return _locationItems; }
        }

        private List<Promotion> _promotions = new List<Promotion>();
        [RelationshipList("90853C4A-31F5-4A46-BC4E-8A93FBE0ED42", nameof(Promotion.LocationID), AutoRemoveReferences = true)]
        public IReadOnlyCollection<Promotion> Promotions
        {
            get { CheckGet(); return _promotions; }
        }

        private List<StorePricingAutomationLocation> _storePricingAutomationLocations = new List<StorePricingAutomationLocation>();
        [RelationshipList("E3C485FA-C706-4172-ACEC-718B8D016E55", nameof(StorePricingAutomationLocation.LocationIDDestination), AutoDeleteReferences = true)]
        public IReadOnlyCollection<StorePricingAutomationLocation> StorePricingAutomationLocations
        {
            get { CheckGet(); return _storePricingAutomationLocations; }
        }
        #endregion
        #region fleet
        private List<LeaseRequest> _leaseRequests = new List<LeaseRequest>();
            [RelationshipList("CC3820D7-F975-44D3-B22C-69FC070A7704", nameof(LeaseRequest.LocationIDChargeTo))]
            public IReadOnlyCollection<LeaseRequest> LeaseRequests
            {
                get { CheckGet(); return _leaseRequests; }
            }

            private List<LeaseBid> _leaseBidRecurringDestinations = new List<LeaseBid>();
            [RelationshipList("F084805B-8F14-45EA-940B-646F97AF9268", nameof(LeaseBid.LocationIDInvoiceDestination))]
            public IReadOnlyCollection<LeaseBid> LeaseBidRecurringDestinations
            {
                get { CheckGet(); return _leaseBidRecurringDestinations; }
            }

            private List<LeaseContract> _leaseContractRecurringSources = new List<LeaseContract>();
            [RelationshipList("1B601D65-BFF5-40D0-8E11-A1624D12E3A3", nameof(LeaseContract.LocationIDRecurringAmountSource))]
            public IReadOnlyCollection<LeaseContract> LeaseContractRecurringSources
            {
                get { CheckGet(); return _leaseContractRecurringSources; }
            }

            private List<LeaseContract> _leaseContractRecurringDestinations = new List<LeaseContract>();
            [RelationshipList("DF30485C-668A-4686-B512-F7B15EC6B3E9", nameof(LeaseContract.LocationIDRecurringAmountDestination))]
            public IReadOnlyCollection<LeaseContract> LeaseContractRecurringDestinations
            {
                get { CheckGet(); return _leaseContractRecurringDestinations; }
            }
            #endregion
        #region invoicing
        private List<Invoice> _invoicesFrom = new List<Invoice>();
        [RelationshipList("6DD822E0-7449-4F56-AF7C-559C44E94EA0", "LocationIDFrom")]
        public IReadOnlyCollection<Invoice> InvoicesFrom
        {
            get { CheckGet(); return _invoicesFrom; }
        }

        private List<Invoice> _invoicesTo = new List<Invoice>();
        [RelationshipList("1C3F6214-C3E8-4882-9F10-10CF7BC7A8DE", "LocationIDTo")]
        public IReadOnlyCollection<Invoice> InvoicesTo
        {
            get { CheckGet(); return _invoicesTo; }
        }
        #endregion
        #region mesasys
        private List<NotificationSubscriberEntity> _notificationSubscriberEntities = new List<NotificationSubscriberEntity>();
        [RelationshipList("C558A461-C3B9-471E-9D8E-24B0114E665A", nameof(NotificationSubscriberEntity.LocationID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<NotificationSubscriberEntity> NotificationSubscriberEntities
        {
            get { CheckGet(); return _notificationSubscriberEntities; }
        }

        private List<NotificationEventEntity> _notificationEventEntities = new List<NotificationEventEntity>();
        [RelationshipList("3A3292FC-B5FA-469A-9DDB-678DC5D2A9ED", nameof(NotificationEventEntity.LocationID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<NotificationEventEntity> NotificationEventEntities
        {
            get { CheckGet(); return _notificationEventEntities; }
        }
        #endregion
        #endregion
    }
}
