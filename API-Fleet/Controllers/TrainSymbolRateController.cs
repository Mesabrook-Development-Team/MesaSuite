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
    [ProgramAccess(new[] { "company", "gov" })]
    public class TrainSymbolRateController : DataObjectController<TrainSymbolRate>
    {
        private long? CompanyID => Request.Headers.Contains("CompanyID") ? long.Parse(Request.Headers.GetValues("CompanyID").First()) : (long?)null;
        private long? GovernmentID => Request.Headers.Contains("GovernmentID") ? long.Parse(Request.Headers.GetValues("GovernmentID").First()) : (long?)null;

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<TrainSymbolRate>(tsr => new List<object>()
        {
            tsr.TrainSymbolRateID,
            tsr.TrainSymbolID,
            tsr.EffectiveTime,
            tsr.RatePerCar,
            tsr.RatePerPartialTrip,
            tsr.TrainSymbol.TrainSymbolID,
            tsr.TrainSymbol.CompanyIDOperator,
            tsr.TrainSymbol.GovernmentIDOperator
        });

        public TrainSymbolRateController() : base()
        {
            PutSecurityCheck += OperatorOnlySecurityCheck;
            PostSecurityCheck += OperatorOnlySecurityCheck;
            DeleteSecurityCheck += OperatorOnlySecurityCheck;
            PatchSecurityCheck += OperatorOnlySecurityCheck;
        }

        private void OperatorOnlySecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            TrainSymbol symbol = DataObject.GetReadOnlyByPrimaryKey<TrainSymbolRate>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<TrainSymbolRate>(tsr => new List<object>() { tsr.TrainSymbol.CompanyIDOperator, tsr.TrainSymbol.GovernmentIDOperator })).TrainSymbol;
            if (symbol == null)
            {
                return;
            }

            e.IsValid &= symbol.CompanyIDOperator == CompanyID && symbol.GovernmentIDOperator == GovernmentID;
        }
    }
}