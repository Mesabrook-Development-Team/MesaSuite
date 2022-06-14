namespace CompanyStudio.Models
{
    public class InvoiceLine
    {
        public long? InvoiceLineID { get; set; }
        public long? InvoiceID { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Total { get; set; }
        public string Description { get; set; }
    }
}
