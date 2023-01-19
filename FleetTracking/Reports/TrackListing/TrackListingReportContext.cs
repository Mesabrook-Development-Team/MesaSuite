using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FleetTracking.Interop;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.TrackListing
{
    public class TrackListingReportContext : IReportContext
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
    }
}
