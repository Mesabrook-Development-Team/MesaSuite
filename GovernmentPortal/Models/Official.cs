namespace GovernmentPortal.Models
{
    public class Official
    {
        public long OfficialID { get; set; }
        public long GovernmentID { get; set; }
        public long UserID { get; set; }
        public bool ManageEmails { get; set; }
        public bool ManageOfficials { get; set; }
        public bool ManageAccounts { get; set; }
        public bool ManageTaxes { get; set; }
        public string OfficialName { get; set; }
        public bool CanMintCurrency { get; set; }
    }
}
