using FleetTracking.Models;

namespace FleetTracking.Reports.RailActivity
{
    public class RailcarLocationTransactionModel : RailcarLocationTransaction
    {
        public string ReportingMark => Railcar?.FormattedReportingMark;
        public string PreviousLocation => PreviousTransaction?.TrainNew?.TrainSymbol?.Name ?? PreviousTransaction?.TrackNew?.Name;
        public string CurrentLocation => TrainNew?.TrainSymbol?.Name ?? TrackNew?.Name;
        public string NextLocation => NextTransaction?.TrainNew?.TrainSymbol?.Name ?? NextTransaction?.TrackNew?.Name;
        public string PossessedByName => PossessedByCompany?.Name ?? PossessedByGovernment?.Name;
    }
}
