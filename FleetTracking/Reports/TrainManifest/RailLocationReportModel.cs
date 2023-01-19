using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetTracking.Models;

namespace FleetTracking.Reports.TrainManifest
{
    public class RailLocationReportModel : RailLocation
    {
        public string TrainSymbolName => Train?.TrainSymbol?.Name;
        public string FormattedReportingMark => RailcarID == null ? Locomotive?.FormattedReportingMark : Railcar?.FormattedReportingMark;
        // Locomotive-Specific
        public decimal? LastReportedFuel => Train?.TrainFuelRecords?.FirstOrDefault(tfr => tfr.LocomotiveID == LocomotiveID)?.FuelStart;

        // Railcar-Specific
        public string FormattedLoad => Railcar?.FormattedRailcarLoads;
        public string Destination => Railcar?.TrackDestination?.Name;
        public string StrategicDestination => Railcar?.TrackStrategic?.Name;
    }
}
