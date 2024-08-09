using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;
using System;
using System.Collections.Generic;
using WebModels.company;
using WebModels.gov;
using WebModels.invoicing;

namespace WebModels.purchasing
{
    [Table("1D36A22A-14A1-4D70-B413-F5FCAF3C1B87")]
    public class PurchaseOrder : DataObject
    {
        protected PurchaseOrder() : base() { }

        private long? _purchaseOrderID;
        [Field("F9C0C9E3-8F6B-4F6F-8D8F-6F8D8F8D8F8D")]
        public long? PurchaseOrderID
        {
            get { CheckGet(); return _purchaseOrderID; }
            set { CheckGet(); _purchaseOrderID = value; }
        }

        private long? _companyIDOrigin;
        [Field("914E2A3E-D966-47AA-9F0F-281685E0109E")]
        public long? CompanyIDOrigin
        {
            get { CheckGet(); return _companyIDOrigin; }
            set { CheckGet(); _companyIDOrigin = value; }
        }

        private Company _companyOrigin = null;
        [Relationship("F8F74C15-F8A7-48F2-9101-202F5B31253E", ForeignKeyField = nameof(CompanyIDOrigin))]
        public Company CompanyOrigin
        {
            get { CheckGet(); return _companyOrigin; }
        }

        private long? _governmentIDOrigin;
        [Field("8AA90984-AF2D-485B-8BE1-5F446CEF504C")]
        public long? GovernmentIDOrigin
        {
            get { CheckGet(); return _governmentIDOrigin; }
            set { CheckGet(); _governmentIDOrigin = value; }
        }

        private Government _governmentOrigin = null;
        [Relationship("A3512448-6DCC-49B7-83EA-5883696C699B", ForeignKeyField = nameof(GovernmentIDOrigin))]
        public Government GovernmentOrigin
        {
            get { CheckGet(); return _governmentOrigin; }
        }

        private long? _companyIDDestination;
        [Field("55694D3A-8BBA-4F95-9884-45A85D9B8051")]
        public long? CompanyIDDestination
        {
            get { CheckGet(); return _companyIDDestination; }
            set { CheckGet(); _companyIDDestination = value; }
        }

        private Company _companyDestination = null;
        [Relationship("BB019C65-99CD-40BA-A9F6-F0283D02FCC3", ForeignKeyField = nameof(CompanyIDDestination))]
        public Company CompanyDestination
        {
            get { CheckGet(); return _companyDestination; }
        }

        private long? _governmentIDDestination;
        [Field("94970F64-69D2-42AE-BD76-22700EE35591")]
        public long? GovernmentIDDestination
        {
            get { CheckGet(); return _governmentIDDestination; }
            set { CheckGet(); _governmentIDDestination = value; }
        }

        private Government _governmentDestination = null;
        [Relationship("F79988B1-0395-4CB1-BA08-C37AC1B59A8F", ForeignKeyField = nameof(GovernmentIDDestination))]
        public Government GovernmentDestination
        {
            get { CheckGet(); return _governmentDestination; }
        }

        private DateTime? _purchaseOrderDate;
        [Field("5E4FEF5E-887B-4DC8-B1C3-1F9A33ABC4CD", DataSize = 7)]
        public DateTime? PurchaseOrderDate
        {
            get { CheckGet(); return _purchaseOrderDate; }
            set { CheckGet(); _purchaseOrderDate = value; }
        }

        public enum Statuses
        {
            Draft,
            Pending,
            Accepted,
            Rejected,
            InProgress,
            Completed
        }

        private Statuses _status;
        [Field("A50DF475-536B-4219-91C9-62C5729A8DDC")]
        public Statuses Status
        {
            get { CheckGet(); return _status; }
            set { CheckGet(); _status = value; }
        }

        private string _description;
        [Field("A977CA7B-98F4-4B01-85E0-BBF99106F4CA", DataSize = 250)]
        [Required]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckGet(); _description = value; }
        }

        #region Relationships
        #region invoicing
        private List<Invoice> _invoices = new List<Invoice>();
        [RelationshipList("B9866DDC-19F1-42F8-8905-E80C8CC8CEA1", nameof(Invoice.PurchaseOrderID))]
        public IReadOnlyCollection<Invoice> Invoices
        {
            get { CheckGet(); return _invoices; }
        }
        #endregion
        #region purchasing
        private List<PurchaseOrderLine> _purchaseOrderLines = new List<PurchaseOrderLine>();
        [RelationshipList("F890FC5F-207A-43FC-B8A1-A42DF5288D5F", nameof(PurchaseOrderLine.PurchaseOrderID), AutoDeleteReferences = true)]
        public IReadOnlyCollection<PurchaseOrderLine> PurchaseOrderLines
        {
            get { CheckGet(); return _purchaseOrderLines; }
        }
        #endregion
        #endregion
    }
}
