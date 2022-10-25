using System.Collections.Generic;
using System.Linq;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
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

        private long? _emailImplementationIDPayableInvoice;
        [Field("EC680184-ADE4-4F81-8DA8-47BAA42E9647")]
        public long? EmailImplementationIDPayableInvoice
        {
            get { CheckGet(); return _emailImplementationIDPayableInvoice; }
            set { CheckSet(); _emailImplementationIDPayableInvoice = value; }
        }

        private EmailImplementation _emailImplementationPayableInvoice = null;
        [Relationship("8524C29D-6CA0-47FD-84AE-D742DB329090", ForeignKeyField = nameof(EmailImplementationIDPayableInvoice))]
        public EmailImplementation EmailImplementationPayableInvoice
        {
            get { CheckGet(); return _emailImplementationPayableInvoice; }
        }

        private long? _emailImplementationIDReadyForReceipt;
        [Field("EC680184-ADE4-4F81-8DA8-47BAA42E9647")]
        public long? EmailImplementationIDReadyForReceipt
        {
            get { CheckGet(); return _emailImplementationIDReadyForReceipt; }
            set { CheckSet(); _emailImplementationIDReadyForReceipt = value; }
        }

        private EmailImplementation _emailImplementationReadyForReceipt = null;
        [Relationship("8524C29D-6CA0-47FD-84AE-D742DB329090", ForeignKeyField = nameof(EmailImplementationIDReadyForReceipt))]
        public EmailImplementation EmailImplementationReadyForReceipt
        {
            get { CheckGet(); return _emailImplementationReadyForReceipt; }
        }

        protected override bool PostSave(ITransaction transaction)
        {
            if (!IsInsert)
            {
                bool deleteSuccessful = true;
                if (IsFieldDirty(nameof(EmailImplementationIDPayableInvoice)))
                {
                    long? previousEmailImpID = GetDirtyValue(nameof(EmailImplementationIDPayableInvoice)) as long?;
                    if (previousEmailImpID != null)
                    {
                        EmailImplementation oldImplementation = DataObject.GetEditableByPrimaryKey<EmailImplementation>(previousEmailImpID, transaction, null);
                        if (!oldImplementation.Delete(transaction))
                        {
                            Errors.AddRange(oldImplementation.Errors.ToArray());
                            deleteSuccessful = false;
                        }
                    }
                }


                if (IsFieldDirty(nameof(EmailImplementationIDReadyForReceipt)))
                {
                    long? previousEmailImpID = GetDirtyValue(nameof(EmailImplementationIDReadyForReceipt)) as long?;
                    if (previousEmailImpID != null)
                    {
                        EmailImplementation oldImplementation = DataObject.GetEditableByPrimaryKey<EmailImplementation>(previousEmailImpID, transaction, null);
                        if (!oldImplementation.Delete(transaction))
                        {
                            Errors.AddRange(oldImplementation.Errors.ToArray());
                            deleteSuccessful = false;
                        }
                    }
                }

                return deleteSuccessful;
            }

            return base.PostSave(transaction);
        }

        #region Relationships
        #region company
        private List<LocationEmployee> _locationEmployees = new List<LocationEmployee>();
        [RelationshipList("04569132-78B1-42E6-BD47-5729B5B392ED", "LocationID")]
        public IReadOnlyCollection<LocationEmployee> LocationEmployees
        {
            get { CheckGet(); return _locationEmployees; }
        }

        private List<LocationGovernment> _locationGovernments = new List<LocationGovernment>();
        [RelationshipList("5C8358F5-676C-468E-A745-EBAF6754C67E", "LocationID")]
        public IReadOnlyCollection<LocationGovernment> LocationGovernments
        {
            get { CheckGet(); return _locationGovernments; }
        }
        #endregion
        #region fleet
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
        #endregion
    }
}
