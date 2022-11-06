namespace FleetTracking.Models
{
    public class Locomotive
    {
        public long? LocomotiveID { get; set; }
        public long? LocomotiveModelID { get; set; }
        public LocomotiveModel LocomotiveModel { get; set; }
        public long? CompanyIDOwner { get; set; }
        public Company CompanyOwner { get; set; }
        public long? GovernmentIDOwner { get; set; }
        public Government GovernmentOwner { get; set; }
        public long? CompanyIDPossessor { get; set; }
        public Company CompanyPossessor { get; set; }
        public long? GovernmentIDPossessor { get; set; }
        public Government GovernmentPossessor { get; set; }
        public Company CompanyLeasedTo { get; set; }
        public Government GovernmentLeasedTo { get; set; }
        public string ReportingMark { get; set; }
        public int? ReportingNumber { get; set; }
        public bool HasOpenBid { get; set; }
        public string FormattedReportingMark
        {
            get
            {
                if (string.IsNullOrEmpty(ReportingMark) && ReportingNumber == null)
                {
                    return null;
                }

                return $"{ReportingMark}{ReportingNumber}";
            }
        }
    }
}
