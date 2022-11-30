using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "company", "gov" })]
    public class TrainController : DataObjectController<Train>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Train>(t => new List<object>()
        {
            t.TrainID,
            t.TrainSymbolID,
            t.Status,
            t.TrainSymbol.TrainSymbolID,
            t.TrainSymbol.Name,
            t.TrainSymbol.CompanyIDOperator,
            t.TrainSymbol.GovernmentIDOperator,
            t.TrainDutyTransactions.First().TrainDutyTransactionID,
            t.TrainDutyTransactions.First().TimeOnDuty,
            t.TrainDutyTransactions.First().TimeOffDuty,
            t.RailLocations.First().RailLocationID,
            t.RailLocations.First().TrainID,
            t.RailLocations.First().LocomotiveID,
            t.RailLocations.First().Locomotive.LocomotiveID,
            t.RailLocations.First().Locomotive.ReportingMark,
            t.RailLocations.First().Locomotive.ReportingNumber,
            t.RailLocations.First().Locomotive.LocomotiveModelID,
            t.RailLocations.First().Locomotive.LocomotiveModel.LocomotiveModelID
            t.RailLocations.First().Locomotive.LocomotiveModel.Length,
            t.RailLocations.First().RailcarID,
            t.RailLocations.First().Railcar.RailcarID,
            t.RailLocations.First().Railcar.ReportingMark,
            t.RailLocations.First().Railcar.ReportingNumber,
            t.RailLocations.First().Railcar.RailcarModelID,
            t.RailLocations.First().Railcar.RailcarModel.RailcarModelID,
            t.RailLocations.First().Railcar.RailcarModel.Length
        });
    }
}