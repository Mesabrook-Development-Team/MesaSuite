using System;

namespace FleetTracking.Models
{
    [Serializable()]
    public class RailLocation
    {
        public RailLocation() { }

        public long? RailLocationID { get; set; }
        public long? RailcarID { get; set; }
        private Railcar _railcar;
        public Railcar Railcar
        {
            get => _railcar;
            set => _railcar = value;
        }
        public long? LocomotiveID { get; set; }
        public Locomotive Locomotive { get; set; }
        public int Position { get; set; }
        public long? TrackID { get; set; }
        public Track Track { get; set; }
        public long? TrainID { get; set; }
        public Train Train { get; set; }
    }
}
