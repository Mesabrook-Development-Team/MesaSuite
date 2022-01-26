using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;

namespace WebModels.invoicing
{
    [Table("364C1CE8-EF58-4FDC-BC22-C029E50891B4")]
    public class InvoiceSalesTax : DataObject
    {
        protected InvoiceSalesTax() : base() { }

        private long? _invoiceSalesTaxID;
        [Field("3B8F2D83-686C-40EC-94DF-DA1D9A8462DC")]
        public long? InvoiceSalesTaxID
        {
            get { CheckGet(); return _invoiceSalesTaxID; }
            set { CheckSet(); _invoiceSalesTaxID = value; }
        }

        private long? _invoiceID;
        [Field("92777FA0-C6BE-47AF-AFEE-F94E34035BC3")]
        public long? InvoiceID
        {
            get { CheckGet(); return _invoiceID; }
            set { CheckSet(); _invoiceID = value; }
        }

        private Invoice _invoice = null;
        [Relationship("7672AE8F-A5FF-4A49-A803-779AD780C06E")]
        public Invoice Invoice
        {
            get { CheckGet(); return _invoice; }
        }

        private string _municipality;
        [Field("233EA475-1D1A-4C4E-9F47-A8463E7FBA06", DataSize = 50)]
        public string Municipality
        {
            get { CheckGet(); return _municipality; }
            set { CheckSet(); _municipality = value; }
        }

        private decimal? _rate;
        [Field("88E4AFE6-D78F-4F71-A409-00A4823865EF", DataSize = 5, DataScale = 2)]
        public decimal? Rate
        {
            get { CheckGet(); return _rate; }
            set { CheckSet(); _rate = value; }
        }

        private decimal? _appliedAmount;
        [Field("DB3019E0-D714-4B97-95A1-8D9BA0C71264", DataSize = 9, DataScale = 2)]
        public decimal? AppliedAmount
        {
            get { CheckGet(); return _appliedAmount; }
            set { CheckSet(); _appliedAmount = value; }
        }
    }
}
