namespace FleetTracking.Models
{
    public class TrainFuelRecord
    {
        public long? TrainFuelRecordID { get; set; }
        public long? TrainID { get; set; }
        public Train Train { get; set; }
        public long? LocomotiveID { get; set; }
        public Locomotive Locomotive { get; set; }
        public decimal? FuelStart { get; set; }
        public decimal? FuelEnd { get; set; }
    }
}
