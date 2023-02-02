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
        public RailLocation RailLocation { get; set; }
        public string Location
        {
            get
            {
                string location = "";
                if (RailLocation?.TrackID != null)
                {
                    location = RailLocation.Track?.Name + " (" + RailLocation.Track?.RailDistrict?.Name + ")";
                }
                else if (RailLocation?.TrainID != null)
                {
                    if (RailLocation.Train?.TimeOnDuty == null)
                    {
                        location = "--/--/---- --:-- - " + RailLocation.Train?.TrainSymbol?.Name;
                    }
                    else
                    {
                        location = RailLocation.Train.TimeOnDuty.Value.ToString("MM/dd/yyyy HH:mm") + " - " + RailLocation.Train.TrainSymbol?.Name;
                    }
                }

                return location;
            }
        }
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
