using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FleetTracking.Interop;
using FleetTracking.Models;
using MesaSuite.Common.Data;

namespace FleetTracking.Reports.TrainManifest
{
    public class TrainManifestReportContext : IReportContext, INetworkPrintable
    {
        private FleetTrackingApplication _application;
        public FleetTrackingApplication Application { set => _application = value; }

        public List<long?> TrainIDs { get; set; }

        public TrainManifestReportContext(FleetTrackingApplication application, IEnumerable<long?> trainIDs)
        {
            _application = application;
            TrainIDs = trainIDs.ToList();
        }

        public string WindowTitle => "Train Manifest";

        public string ReportPath => "FleetTracking.Reports.TrainManifest.Manifest.rdlc";

        public async Task<Dictionary<string, object>> GetReportDataSources()
        {
            List<RailLocationReportModel> railLocations = new List<RailLocationReportModel>();
            foreach (long? trainID in TrainIDs)
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"RailLocation/GetByTrain/{trainID}";
                railLocations.AddRange(await get.GetObject<List<RailLocationReportModel>>());
            }

            return new Dictionary<string, object>()
            {
                { "RailLocationReportModel", railLocations },
                { "FleetTracking.Reports.TrainManifest.Locomotives.rdlc.RailLocationReportModel", railLocations },
                { "FleetTracking.Reports.TrainManifest.Railcars.rdlc.RailLocationReportModel", railLocations }
            };
        }

        public async Task NetworkPrint(long? printerID, string fileName)
        {
            List<RailLocationReportModel> railLocations = new List<RailLocationReportModel>();
            foreach (long? trainID in TrainIDs)
            {
                GetData get = _application.GetAccess<GetData>();
                get.API = DataAccess.APIs.FleetTracking;
                get.Resource = $"RailLocation/GetByTrain/{trainID}";
                railLocations.AddRange(await get.GetObject<List<RailLocationReportModel>>());
            }

            NetworkReportBuilder builder = new NetworkReportBuilder();
            builder.Groupings.Add(new PrintLine() { Text = "§lTRAIN MANIFEST", Alignment = PrintLine.Alignments.Center });
            RailLocationReportModel railLocationForHeader = railLocations.FirstOrDefault();
            string trainOperator = railLocationForHeader?.Train.TrainSymbol.CompanyOperator?.Name ?? railLocationForHeader?.Train.TrainSymbol.GovernmentOperator?.Name;
            builder.Groupings.Add(new string[]
            {
                $"§lTrain: §r{railLocationForHeader?.TrainSymbolName}",
                $"§lOperator: §r{railLocationForHeader?.TrainSymbolOperator}",
                ""
            });

            List<RailLocationReportModel> locomotives = railLocations.Where(rl => rl.LocomotiveID != null).ToList();
            builder.Groupings.Add("§lLocomotives:");
            foreach(RailLocationReportModel locomotive in locomotives)
            {
                builder.Groupings.Add(new[]
                {
                    $"§lID: §r{locomotive.FormattedReportingMark}",
                    $"§lFuel: §r{locomotive.LastReportedFuel}",
                    $"§lLength: §r{locomotive.Length}",
                    $"§lPos: §r{locomotive.Position}",
                    ""
                });
            }
            builder.Groupings.Add(new[]
            {
                $"§nLoco Total: {locomotives.Count}",
                $"§nLoco Length: {locomotives.Sum(l => l.Length)}",
                ""
            });

            List<RailLocationReportModel> railcars = railLocations.Where(rl => rl.RailcarID != null).ToList();
            builder.Groupings.Add("§lRailcars:");
            foreach (RailLocationReportModel railcar in railcars)
            {
                builder.Groupings.Add(new[]
                {
                    $"§lID: §r{railcar.FormattedReportingMark}",
                    $"§lContents: §r{railcar.FormattedLoad}",
                    $"§lStrtgc: §r{railcar.StrategicDestination}",
                    $"§lDest: §r{railcar.Destination}",
                    $"§lLength: §r{railcar.Length}",
                    $"§lPos: §r{railcar.Position}",
                    ""
                });
            }
            builder.Groupings.Add(new[]
            {
                $"§nRailcar Total: §r{railcars.Count}",
                $"§nRailcar Length: §r{railcars.Sum(l => l.Length)}",
                ""
            });

            builder.Groupings.Add(new[]
            {
                $"§nStock Total: §r{railLocations.Count}",
                $"§nTrain Length: §r{railLocations.Sum(rl => rl.Length)}"
            });

            await builder.SaveNetworkReport(printerID, fileName);
        }
    }
}
