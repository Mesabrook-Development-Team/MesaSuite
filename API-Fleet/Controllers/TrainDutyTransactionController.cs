using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class TrainDutyTransactionController : DataObjectController<TrainDutyTransaction>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<TrainDutyTransaction>(tdt => new List<object>()
        {
            tdt.TrainDutyTransactionID,
            tdt.UserIDOperator,
            tdt.UserOperator.UserID,
            tdt.UserOperator.Username,
            tdt.TimeOnDuty,
            tdt.TimeOffDuty
        });

        public TrainDutyTransactionController() : base()
        {
            PostSecurityCheck += EditSecurityCheck;
            PutSecurityCheck += EditSecurityCheck;
            DeleteSecurityCheck += EditSecurityCheck;
            PatchSecurityCheck += EditSecurityCheck;
        }

        private void EditSecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            TrainSymbol symbol = new Search<TrainDutyTransaction>(new LongSearchCondition<TrainDutyTransaction>()
            {
                Field = "TrainID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = e.ObjectID
            }).GetReadOnly(e.Transaction, FieldPathUtility.CreateFieldPathsAsList<TrainDutyTransaction>(tdt => new List<object>() { tdt.Train.TrainSymbol.CompanyIDOperator, tdt.Train.TrainSymbol.GovernmentIDOperator }))?.Train?.TrainSymbol;

            e.IsValid &= this.GovernmentID() == symbol?.GovernmentIDOperator && this.CompanyID() == symbol?.CompanyIDOperator;
        }

        [HttpGet]
        public async Task<List<TrainDutyTransaction>> GetByTrain(long? id)
        {
            return new Search<TrainDutyTransaction>(new LongSearchCondition<TrainDutyTransaction>()
            {
                Field = "TrainID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            }).GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}