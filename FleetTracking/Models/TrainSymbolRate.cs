using System;

namespace FleetTracking.Models
{
    public class TrainSymbolRate
    {
        public long? TrainSymbolRateID { get; set; }
        public long? TrainSymbolID { get; set; }
        public TrainSymbol TrainSymbol { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public decimal? RatePerCar { get; set; }
        public decimal? RatePerPartialTrip { get; set; }
    }
}
