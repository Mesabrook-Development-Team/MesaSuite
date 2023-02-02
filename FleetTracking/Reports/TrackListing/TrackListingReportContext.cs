using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.TrackListing
{
    public class TrackListingReportContext : IReportContext, INetworkPrintable
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public List<long?> TrackIDs { get; set; } = new List<long?>();

        public TrackListingReportContext(IEnumerable<long?> trackIDs)
        {
            TrackIDs = trackIDs.ToList();
        }

        public string WindowTitle => "Track Listing";

        public string ReportPath => "FleetTracking.Reports.TrackListing.Track.rdlc";

        public async Task<Dictionary<string, object>> GetReportDataSources()
        {
            List<RailLocationModel> railLocationModels = new List<RailLocationModel>();
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;
            foreach(long? trackID in TrackIDs)
            {
                get.Resource = $"RailLocation/GetByTrack/{trackID}";
                List<RailLocationModel> railLocations = await get.GetObject<List<RailLocationModel>>() ?? new List<RailLocationModel>();
                railLocations = railLocations.OrderBy(rl => rl.Position).ToList();
                railLocationModels.AddRange(railLocations);
            }

            return new Dictionary<string, object>()
            {
                { "ReportModel", railLocationModels }
            };
        }

        public async Task NetworkPrint(long? printerID, string fileName)
        {
            GetData get = _application.GetAccess<GetData>();
            get.API = DataAccess.APIs.FleetTracking;

            foreach (long? trackID in TrackIDs)
            {
                get.Resource = $"RailLocation/GetByTrack/{trackID}";
                List<RailLocation> railLocations = await get.GetObject<List<RailLocation>>() ?? new List<RailLocation>();
                railLocations = railLocations.OrderBy(rl => rl.Position).ToList();

                NetworkReportBuilder builder = new NetworkReportBuilder()
                {
                    Groupings = new List<NetworkReportBuilder.Grouping>()
                    {
                        new PrintLine() { Text = "§lSTOCK BY TRACK", Alignment = PrintLine.Alignments.Center },
                        $"§lTrack: §r{railLocations.First()?.Track?.Name}",
                        "",
                        "§lCars on track:"
                    }
                };

                foreach(RailLocation location in railLocations)
                {
                    string type = location.RailcarID == null ? "L" : "R";
                    builder.Groupings.Add(new string[]
                        {
                            $"§lID: §r{location.Railcar?.FormattedReportingMark ?? location.Locomotive?.FormattedReportingMark} ({type})",
                            $"§lStrtgc: §r{location.Railcar?.TrackStrategic?.Name}",
                            $"§lDest: §r{location.Railcar?.TrackDestination?.Name}",
                            $"§lPos: §r{location.Position}",
                            ""
                        });
                }

                await builder.SaveNetworkReport(printerID, fileName);
            }
        }
    }
}
