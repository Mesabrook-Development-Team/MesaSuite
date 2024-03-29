﻿using System;
using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class Train
    {
        public long? TrainID { get; set; }
        public long? TrainSymbolID { get; set; }
        public TrainSymbol TrainSymbol { get; set; }
        public string TrainInstructions { get; set; }
        public enum Statuses
        {
            NotStarted,
            EnRoute,
            Complete
        }
        public Statuses Status { get; set; }

        public List<TrainFuelRecord> TrainFuelRecords { get; set; }
        public List<RailLocation> RailLocations { get; set; }
        public List<TrainDutyTransaction> TrainDutyTransactions { get; set; }

        public DateTime? TimeOnDuty { get; set; }
        public LiveLoad LiveLoad { get; set; }
    }
}
