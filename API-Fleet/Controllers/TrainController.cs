using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "company", "gov" })]
    public class TrainController : DataObjectController<Train>
    {
        private long? CompanyID => Request.Headers.Contains("CompanyID") ? long.Parse(Request.Headers.GetValues("CompanyID").First()) : (long?)null;
        private long? GovernmentID => Request.Headers.Contains("GovernmentID") ? long.Parse(Request.Headers.GetValues("GovernmentID").First()) : (long?)null;

        public TrainController() : base()
        {
            PostSecurityCheck += TrainController_EditSecurityCheck;
            PutSecurityCheck += TrainController_EditSecurityCheck;
            DeleteSecurityCheck += TrainController_EditSecurityCheck;
            PatchSecurityCheck += TrainController_EditSecurityCheck;
        }

        private void TrainController_EditSecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            TrainSymbol symbol = DataObject.GetReadOnlyByPrimaryKey<Train>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<Train>(t => new List<object>()
            {
                t.TrainSymbol.CompanyIDOperator,
                t.TrainSymbol.GovernmentIDOperator
            })).TrainSymbol;

            e.IsValid &= CompanyID == symbol.CompanyIDOperator && GovernmentID == symbol.GovernmentIDOperator;
        }

        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<Train>(t => new List<object>()
        {
            t.TrainID,
            t.TrainSymbolID,
            t.TrainInstructions,
            t.Status,
            t.TimeOnDuty,
            t.TrainSymbol.TrainSymbolID,
            t.TrainSymbol.Name,
            t.TrainSymbol.CompanyIDOperator,
            t.TrainSymbol.GovernmentIDOperator,
            t.TrainFuelRecords.First().LocomotiveID,
            t.TrainFuelRecords.First().Locomotive.LocomotiveID,
            t.TrainFuelRecords.First().Locomotive.LocomotiveModelID,
            t.TrainFuelRecords.First().Locomotive.LocomotiveModel.LocomotiveModelID,
            t.TrainFuelRecords.First().Locomotive.LocomotiveModel.Name,
            t.TrainFuelRecords.First().FuelStart,
            t.TrainFuelRecords.First().FuelEnd,
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
            t.RailLocations.First().Locomotive.LocomotiveModel.LocomotiveModelID,
            t.RailLocations.First().Locomotive.LocomotiveModel.Length,
            t.RailLocations.First().RailcarID,
            t.RailLocations.First().Railcar.RailcarID,
            t.RailLocations.First().Railcar.ReportingMark,
            t.RailLocations.First().Railcar.ReportingNumber,
            t.RailLocations.First().Railcar.RailcarModelID,
            t.RailLocations.First().Railcar.RailcarModel.RailcarModelID,
            t.RailLocations.First().Railcar.RailcarModel.Length,
            t.LiveLoad.LiveLoadID
        });

        public override bool AllowGetAll => true;

        public async Task<List<Train>> GetByTrainSymbol(long? id)
        {
            Search<Train> trainSearch = new Search<Train>(new LongSearchCondition<Train>()
            {
                Field = nameof(Train.TrainSymbolID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return trainSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetFiltered([FromUri]string status = "inprogress", [FromUri]bool operableonly = true, [FromUri]int skip = 0, [FromUri]int take = 50)
        {
            SearchConditionGroup conditionGroup = new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And);
            if (string.Equals("inprogress", status, StringComparison.OrdinalIgnoreCase))
            {
                conditionGroup.SearchConditions.Add(new IntSearchCondition<Train>() { Field = "Status", SearchConditionType = SearchCondition.SearchConditionTypes.List, List = new List<int>() { (int)Train.Statuses.NotStarted, (int)Train.Statuses.EnRoute } });
            }

            if (operableonly)
            {
                if (CompanyID != null)
                {
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<Train>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<Train>(t => new List<object>() { t.TrainSymbol.CompanyIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = CompanyID
                    });
                }

                if (GovernmentID != null)
                {
                    conditionGroup.SearchConditions.Add(new LongSearchCondition<Train>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<Train>(t => new List<object>() { t.TrainSymbol.GovernmentIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = GovernmentID
                    });
                }
            }

            Search<Train> trainSearch = new Search<Train>(conditionGroup);
            long max = trainSearch.GetRecordCount();

            trainSearch.Skip = skip;
            trainSearch.Take = take;

            return Json(new
            {
                maxItems = max,
                trains = trainSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList()
            }, GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings);
        }
    }
}