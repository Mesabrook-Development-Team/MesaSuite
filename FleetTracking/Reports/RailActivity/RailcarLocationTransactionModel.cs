using FleetTracking.Models;
using System.Linq;

namespace FleetTracking.Reports.RailActivity
{
    public class RailcarLocationTransactionModel : RailcarLocationTransaction
    {
        public string ReportingMark => Railcar?.FormattedReportingMark;
        public string PreviousLocation => PreviousTransaction?.TrainNew?.TrainSymbol?.Name ?? PreviousTransaction?.TrackNew?.Name;
        public string PreviousDistrict => PreviousTransaction?.TrackNew?.RailDistrict?.Name;
        public string CurrentLocation => TrainNew?.TrainSymbol?.Name ?? TrackNew?.Name;
        public string CurrentDistrict => TrackNew?.RailDistrict?.Name;
        public string NextLocation => NextTransaction?.TrainNew?.TrainSymbol?.Name ?? NextTransaction?.TrackNew?.Name;
        public string PossessedByName => PossessedByCompany?.Name ?? PossessedByGovernment?.Name;

        public decimal? TotalFuelUsage => TrainNew?.TrainFuelRecords?.Sum(tfr => (tfr.FuelStart ?? 0) - (tfr.FuelEnd ?? 0));
        public int TotalMinutesOnDuty => (int)(TrainNew?.TrainDutyTransactions?.Sum(tdt => (tdt.TimeOffDuty - tdt.TimeOnDuty).Value.TotalMinutes) ?? 0);
        public int InterDistrictMoveCounter
        {
            get
            {
                bool isTrackMove = PreviousTransaction?.TrackNew?.RailDistrictID != null && TrackNew?.RailDistrictID != null;
                if (!isTrackMove)
                {
                    return 0;
                }

                return PreviousTransaction?.TrackNew?.RailDistrictID == TrackNew?.RailDistrictID ? 0 : 1;
            }
        }
    }
}
