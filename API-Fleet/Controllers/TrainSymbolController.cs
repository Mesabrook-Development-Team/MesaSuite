using System.Collections.Generic;
using System.Linq;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new string[] { "company", "gov" })]
    public class TrainSymbolController : DataObjectController<TrainSymbol>
    {
        private long? CompanyID => Request.Headers.Contains("CompanyID") ? long.Parse(Request.Headers.GetValues("CompanyID").First()) : (long?)null;
        private long? GovernmentID => Request.Headers.Contains("GovernmentID") ? long.Parse(Request.Headers.GetValues("GovernmentID").First()) : (long?)null;
        public TrainSymbolController() : base()
        {
            PutSecurityCheck += OperatorOnlySecurityCheck;
            PostSecurityCheck += OperatorOnlySecurityCheck;
            DeleteSecurityCheck += OperatorOnlySecurityCheck;
            PatchSecurityCheck += OperatorOnlySecurityCheck;
        }

        private void OperatorOnlySecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            TrainSymbol symbol = DataObject.GetReadOnlyByPrimaryKey<TrainSymbol>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<TrainSymbol>(ts => new List<object>() { ts.CompanyIDOperator, ts.GovernmentIDOperator }));
            if (symbol == null)
            {
                return;
            }

            e.IsValid &= symbol.CompanyIDOperator == CompanyID && symbol.GovernmentIDOperator == GovernmentID;
        }

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<TrainSymbol>(ts => new List<object>()
        {
            ts.TrainSymbolID,
            ts.CompanyIDOperator,
            ts.CompanyOperator.CompanyID,
            ts.CompanyOperator.Name,
            ts.GovernmentIDOperator,
            ts.GovernmentOperator.GovernmentID,
            ts.GovernmentOperator.Name,
            ts.Name,
            ts.Description,
            ts.HasTrainInProgress,
            ts.TrainSymbolRates.First().TrainSymbolRateID,
            ts.TrainSymbolRates.First().TrainSymbolID,
            ts.TrainSymbolRates.First().EffectiveTime,
            ts.TrainSymbolRates.First().RatePerCar,
            ts.TrainSymbolRates.First().RatePerPartialTrip,
            ts.Trains.First().TrainID,
            ts.Trains.First().TrainSymbolID
        });

        public override bool AllowGetAll => true;
    }
}