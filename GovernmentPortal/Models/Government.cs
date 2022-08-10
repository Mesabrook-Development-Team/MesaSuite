namespace GovernmentPortal.Models
{
    public class Government
    {
        public long? GovernmentID { get; set; }
        public string Name { get; set; }
        public string EmailDomain { get; set; }
        public bool CanMintCurrency { get; set; }
        public string InvoiceNumberPrefix { get; set; }
        public string NextInvoiceNumber { get; set; }
        public long? EmailImplementationIDPayableInvoice { get; set; }
        public long? EmailImplementationIDReadyForReceipt { get; set; }
        public long? EmailImplementationIDWireTransferHistory { get; set; }
    }
}
