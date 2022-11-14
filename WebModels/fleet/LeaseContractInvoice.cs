using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using WebModels.invoicing;

namespace WebModels.fleet
{
    [Table("9BE7F6D6-A444-41C1-BEFB-7E5243D114CE")]
    public class LeaseContractInvoice : DataObject
    {
        protected LeaseContractInvoice() : base() { }

        private long? _leaseContractInvoiceID = null;
        [Field("25EFDED8-4ED6-48F3-BF33-21B6F5B41728")]
        public long? LeaseContractInvoiceID
        {
            get { CheckGet(); return _leaseContractInvoiceID; }
        }

        private long? _leaseContractID;
        [Field("B457D5E6-132D-4833-B6BF-36A09E67736C")]
        public long? LeaseContractID
        {
            get { CheckGet(); return _leaseContractID; }
            set { CheckSet(); _leaseContractID = value; }
        }

        private LeaseContract _leaseContract = null;
        [Relationship("6CBEA878-3DD5-49E1-8FD3-C10353119DC3")]
        public LeaseContract LeaseContract
        {
            get { CheckGet(); return _leaseContract; }
        }

        private long? _invoiceID;
        [Field("3A0ABB6A-504F-48CC-A127-171F2EB72AAE")]
        public long? InvoiceID
        {
            get { CheckGet(); return _invoiceID; }
            set { CheckSet(); _invoiceID = value; }
        }

        private Invoice _invoice = null;
        [Relationship("63D44B9B-3461-4E9B-8FEC-C16AFCD6B828")]
        public Invoice Invoice
        {
            get { CheckGet(); return _invoice; }
        }

        public enum Types
        {
            Initial,
            Recurring
        }

        private Types _type;
        [Field("4069C7D5-CCAF-4BA0-9144-A0C5877E51B9")]
        public Types Type
        {
            get { CheckGet(); return _type; }
            set { CheckSet(); _type = value; }
        }

        private DateTime _issueTime;
        [Field("12D4C958-A6A7-49E7-93E4-46D347480210", DataSize = 7)]
        public DateTime IssueTime
        {
            get { CheckGet(); return _issueTime; }
            set { CheckSet(); _issueTime = value; }
        }
    }
}
