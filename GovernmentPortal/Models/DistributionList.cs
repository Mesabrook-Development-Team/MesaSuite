using Newtonsoft.Json;

namespace GovernmentPortal.Models
{
    public class DistributionList
    {
        public int DistributionListID { get; set; }
        public int DistributionListDomainID { get; set; }
        public string DistributionListAddress { get; set; }
        public string DistributionListRequireAddress { get; set; }
        public byte DistributionListMode { get; set; }

        [JsonIgnore]
        public string Mode
        {
            get
            {
                switch(DistributionListMode)
                {
                    case 0:
                        return "Public";
                    case 1:
                        return "Members Only";
                    case 2:
                        return "Specific Address";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
