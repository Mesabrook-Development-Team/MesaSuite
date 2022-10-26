namespace FleetTracking.Models
{
    public class Railcar
    {
        public long? RailcarID { get; set; }
        public long? RailcarModelID { get; set; }
        public RailcarModel RailcarModel { get; set; }
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
        public string FormattedReportingMark => $"{ReportingMark}{ReportingNumber}";
        public bool HasOpenBid { get; set; }
    }
}
