namespace SystemManagement.Models
{
    public class Government
    {
        public long GovernmentID { get; set; }
        public string Name { get; set; }
        public string EmailDomain { get; set; }
        public bool CanMintCurrency { get; set; }
        public bool CanConfigureInterest { get; set; }
    }
}
