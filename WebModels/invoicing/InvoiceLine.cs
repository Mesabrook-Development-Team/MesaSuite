using System;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Schema.Attributes;
using ClussPro.ObjectBasedFramework.Validation.Attributes;

namespace WebModels.invoicing
{
    [Table("54DFF210-FA2B-4FAE-904B-36DF6F676CAF")]
    public class InvoiceLine : DataObject
    {
        protected InvoiceLine() : base() { }

        private long? _invoiceLineID;
        [Field("3E66E30B-9B26-41F4-A4A6-B0EF89637411")]
        public long? InvoiceLineID
        {
            get { CheckGet(); return _invoiceLineID; }
            set { CheckSet(); _invoiceLineID = value; }
        }

        private long? _invoiceID;
        [Field("7950AEDA-F6B3-4CB6-AF73-B20F8D097203")]
        [Required]
        public long? InvoiceID
        {
            get { CheckGet(); return _invoiceID; }
            set { CheckSet(); _invoiceID = value; }
        }

        private Invoice _invoice = null;
        [Relationship("F540657C-2F66-41E3-88C8-4D54A0B6DBF3")]
        public Invoice Invoice
        {
            get { CheckGet(); return _invoice; }
        }

        private decimal? _quantity;
        [Field("A97A47C0-0350-4CC6-BE6C-8251DA45CCAE", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? Quantity
        {
            get { CheckGet(); return _quantity; }
            set { CheckSet(); _quantity = value;}
        }

        private decimal? _unitCost;
        [Field("F282BC93-4834-4DDD-B8B8-A511810840D4", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? UnitCost
        {
            get { CheckGet(); return _unitCost; }
            set { CheckSet(); _unitCost = value; }
        }

        private decimal? _total;
        [Field("E434CC09-F6F7-4A66-87A0-E030F1FE2AF6", DataSize = 9, DataScale = 2)]
        [Required]
        public decimal? Total
        {
            get { CheckGet(); return _total; }
            set { CheckSet(); _total = value; }
        }

        private string _description;
        [Field("A753B10D-0C8B-4F4A-8E4E-77E88EB00A79", DataSize = 300)]
        public string Description
        {
            get { CheckGet(); return _description; }
            set { CheckSet(); _description = value; }
        }

        protected override void PreValidate()
        {
            base.PreValidate();

            Total = Math.Round((Quantity ?? 0M) * (UnitCost ?? 0M), 2, MidpointRounding.AwayFromZero);
        }
    }
}
