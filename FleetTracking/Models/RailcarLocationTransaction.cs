using System;

namespace FleetTracking.Models
{
    public class RailcarLocationTransaction
    {
        public long? RailcarLocationTransactionID { get; set; }
        public long? RailcarID { get; set; }
        public Railcar Railcar { get; set; }
        public long? TrackIDNew { get; set; }
        public Track TrackNew { get; set; }
        public long? TrainIDNew { get; set; }
        public Train TrainNew { get; set; }
        public bool IsPartialTrainTrip { get; set; }
        public DateTime? TransactionTime { get; set; }
        public RailcarLocationTransaction PreviousTransaction { get; set; }
        public RailcarLocationTransaction NextTransaction { get; set; }
        public Company PossessedByCompany { get; set; }
        public Government PossessedByGovernment { get; set; }
    }
}
