using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetTracking.Models;

namespace FleetTracking.Reports.TrackListing
{
    public class RailLocationModel : RailLocation
    {
        public string FormattedReportingMark => string.IsNullOrEmpty(Railcar?.FormattedReportingMark) ? Locomotive?.FormattedReportingMark : Railcar.FormattedReportingMark;

        public string CurrentLocation => string.IsNullOrEmpty(Railcar?.Location) ? Locomotive?.Location : Railcar.Location;

        public string TrackName => Track?.Name;
        public string DistrictName => Track?.RailDistrict?.Name;

        public string FormattedLoad => RailcarID != null ? Railcar?.FormattedRailcarLoads : "";
        public string Destination => Railcar?.TrackDestination?.Name;
        public string StrategicDestination => Railcar?.TrackStrategic?.Name;
        public string StockType => RailcarID == null ? "L" : "R";
    }
}
