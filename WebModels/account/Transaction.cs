using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.account
{
    [Table("58F2C3E9-6915-4198-B721-6036D7288EDC")]
    public class Transaction : DataObject
    {
        protected Transaction() : base() { }

        private long? _transactionID;
        [Field("4235EF13-25B8-475E-B095-725023FBFD81")]
        public long? TransactionID
        {
            get { CheckGet(); return _transactionID; }
            set { CheckSet(); _transactionID = value; }
        }

        private long? _fiscalQuarterID;
        [Field("2E682F97-B336-446C-8AA8-6914C405FA96")]
        public long? FiscalQuarterID
        {
            get { CheckGet(); return _fiscalQuarterID; }
            set { CheckSet(); _fiscalQuarterID = value; }
        }

        private FiscalQuarter _fiscalQuarter = null;
        [Relationship("F2DDB1AA-900E-4F8A-96D7-9153FF6C8A0D")]
        public FiscalQuarter FiscalQuarter
        {
            get { CheckGet(); return _fiscalQuarter; }
        }

        private DateTime? _transactionTime;
        [Field("7D1864C4-73DC-46EF-AACE-C962526E0F04", DataSize = 7)]
        public DateTime? TransactionTime
        {
            get { CheckGet(); return _transactionTime; }
            set { CheckSet(); _transactionTime = value; }
        }

        private decimal? _amount;
        [Field("8C433551-669D-4628-839E-E638D426CC1F", DataSize = 11, DataScale = 2)]
        public decimal? Amount
        {
            get { CheckGet(); return _amount; }
            set { CheckSet(); _amount = value; }
        }

        private string _description;
        [Field("BBFBFFB4-EA7B-4BE2-8493-4ADD497B483E", DataSize = 200)]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value; }
        }

        public static class DescriptionFormats
        {
            public const string CLOSING_DEPOSIT = "Deposit from closing account: {0} ({1})";
            public const string TRANSFER_DEPOSIT = "Transfer from account: {0} ({1})";
            public const string TRANSFER_WITHDRAWAL = "Transfer to account: {0} ({1})";
            public const string INVOICE_PAYMENT = "Accounts payable invoice payment: {0}";
            public const string TAX_PAYMENT = "Tax payment on invoice {0} to government {1}";
            public const string INVOICE_COLLECTED = "Accounts receivable invoice collection: {0}";
            public const string TAX_COLLECTED = "Tax collection on invoice {0}";
            public const string WIRE_TRANSFER_OUT = "Wire Transfer sent to {0}";
            public const string WIRE_TRANSFER_IN = "Wire Transfer received from {0}";
            public const string INTEREST_PAYMENT = "Federal interest payment";
        }
    }
}
