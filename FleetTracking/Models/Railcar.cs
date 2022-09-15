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
        public string ReportingMark { get; set; }
        public int? ReportingNumber { get; set; }
    }
}
