﻿using System.Collections.Generic;

namespace FleetTracking.Models
{
    public class TrainSymbol
    {
        public long? TrainSymbolID { get; set; }
        public long? CompanyIDOperator { get; set; }
        public Company CompanyOperator { get; set; }
        public long? GovernmentIDOperator { get; set; }
        public Government GovernmentOperator { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasTrainInProgress { get; set; }

        public List<Train> Trains { get; set; }
    }
}
