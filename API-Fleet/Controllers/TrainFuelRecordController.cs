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
    public class TrainFuelRecordController : DataObjectController<TrainFuelRecord>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<TrainFuelRecord>(tfr => new List<object>()
        {
            tfr.TrainFuelRecordID,
            tfr.TrainID,
            tfr.LocomotiveID,
            tfr.Locomotive.LocomotiveID,
            tfr.Locomotive.ReportingMark,
            tfr.Locomotive.ReportingNumber,
            tfr.FuelStart,
            tfr.FuelEnd
        });

        public TrainFuelRecordController() : base()
        {
            PostSecurityCheck += EditSecurityCheck;
            PutSecurityCheck += EditSecurityCheck;
            DeleteSecurityCheck += EditSecurityCheck;
            PatchSecurityCheck += EditSecurityCheck;
        }

        private void EditSecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            TrainSymbol symbol = new Search<TrainFuelRecord>(new LongSearchCondition<TrainFuelRecord>()
            {
                Field = "TrainFuelRecordID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = e.ObjectID
            }).GetReadOnly(e.Transaction, FieldPathUtility.CreateFieldPathsAsList<TrainFuelRecord>(tfr => new List<object>() { tfr.Train.TrainSymbol.CompanyIDOperator, tfr.Train.TrainSymbol.GovernmentIDOperator }))?.Train?.TrainSymbol;

            e.IsValid &= this.GovernmentID() == symbol?.GovernmentIDOperator && this.CompanyID() == symbol?.CompanyIDOperator;
        }

        [HttpGet]
        public async Task<List<TrainFuelRecord>> GetByTrain(long? id)
        {
            return new Search<TrainFuelRecord>(new LongSearchCondition<TrainFuelRecord>()
            {
                Field = "TrainID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            }).GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}