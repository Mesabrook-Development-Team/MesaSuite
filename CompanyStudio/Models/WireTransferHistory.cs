using System;

namespace CompanyStudio.Models
{
    public class WireTransferHistory
    {
        public long? WireTransferHistoryID { get; set; }
        public long? GovernmentIDFrom { get; set; }
        public Government GovernmentFrom { get; set; }
        public long? CompanyIDFrom { get; set; }
        public Company CompanyFrom { get; set; }
        public long? GovernmentIDTo { get; set; }
        public Government GovernmentTo { get; set; }
        public long? CompanyIDTo { get; set; }
        public Company CompanyTo { get; set; }
        public DateTime? TransferTime { get; set; }
        public string AccountFromHistorical { get; set; }
        public string AccountFromMasked { get; set; }
        public string AccountToHistorical { get; set; }
        public string AccountToMasked { get; set; }
        public decimal? Amount { get; set; }
        public string Memo { get; set; }
    }
}
