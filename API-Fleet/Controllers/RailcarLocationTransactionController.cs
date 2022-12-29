using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Fleet.Extensions;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using WebModels.fleet;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "government" })]
    public class RailcarLocationTransactionController : DataObjectController<RailcarLocationTransaction>
    {
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>()
        {
            rlt.RailcarLocationTransactionID,
            rlt.RailcarID,
            rlt.Railcar.RailcarID,
            rlt.Railcar.ReportingMark,
            rlt.Railcar.ReportingNumber,
            rlt.TrackIDNew,
            rlt.TrackNew.TrackID,
            rlt.TrackNew.Name,
            rlt.TrainIDNew,
            rlt.TrainNew.TrainID,
            rlt.TrainNew.TrainSymbolID,
            rlt.TrainNew.TrainSymbol.TrainSymbolID,
            rlt.TrainNew.TrainSymbol.Name,
            rlt.PreviousTransaction.TrackIDNew,
            rlt.PreviousTransaction.TrackNew.TrackID,
            rlt.PreviousTransaction.TrackNew.Name,
            rlt.PreviousTransaction.TrainIDNew,
            rlt.PreviousTransaction.TrainNew.TrainID,
            rlt.PreviousTransaction.TrainNew.TrainSymbolID,
            rlt.PreviousTransaction.TrainNew.TrainSymbol.TrainSymbolID,
            rlt.PreviousTransaction.TrainNew.TrainSymbol.Name,
            rlt.NextTransaction.TrackIDNew,
            rlt.NextTransaction.TrackNew.TrackID,
            rlt.NextTransaction.TrackNew.Name,
            rlt.NextTransaction.TrainIDNew,
            rlt.NextTransaction.TrainNew.TrainID,
            rlt.NextTransaction.TrainNew.TrainSymbolID,
            rlt.NextTransaction.TrainNew.TrainSymbol.TrainSymbolID,
            rlt.NextTransaction.TrainNew.TrainSymbol.Name,
            rlt.IsPartialTrainTrip,
            rlt.TransactionTime,
            rlt.InvoiceID,
            rlt.WillNotCharge
        });

        public RailcarLocationTransactionController() : base()
        {
            PostSecurityCheck += EditSecurityCheck;
            PutSecurityCheck += EditSecurityCheck;
            PostSecurityCheck += EditSecurityCheck;
            DeleteSecurityCheck += EditSecurityCheck;
        }

        private void EditSecurityCheck(object sender, SecurityCheckEventArgs e)
        {
            RailcarLocationTransaction railcarLocationTransaction = DataObject.GetReadOnlyByPrimaryKey<RailcarLocationTransaction>(e.ObjectID, e.Transaction, FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>()
            {
                rlt.TrackNew.CompanyIDOwner,
                rlt.TrackNew.GovernmentIDOwner,
                rlt.TrackNew.RailDistrict.CompanyIDOperator,
                rlt.TrackNew.RailDistrict.GovernmentIDOperator,
                rlt.TrainNew.TrainSymbol.CompanyIDOperator,
                rlt.TrainNew.TrainSymbol.GovernmentIDOperator,
                rlt.PreviousTransaction.TrackNew.CompanyIDOwner,
                rlt.PreviousTransaction.TrackNew.GovernmentIDOwner,
                rlt.PreviousTransaction.TrackNew.RailDistrict.CompanyIDOperator,
                rlt.PreviousTransaction.TrackNew.RailDistrict.GovernmentIDOperator,
                rlt.PreviousTransaction.TrainNew.TrainSymbol.CompanyIDOperator,
                rlt.PreviousTransaction.TrainNew.TrainSymbol.GovernmentIDOperator
            }));

            List<long> allowedCompanyIDs = new List<long>()
            {
                railcarLocationTransaction.TrackNew?.CompanyIDOwner ?? 0L,
                railcarLocationTransaction.TrackNew?.RailDistrict?.CompanyIDOperator ?? 0L,
                railcarLocationTransaction.TrainNew?.TrainSymbol?.CompanyIDOperator ?? 0L,
                railcarLocationTransaction.PreviousTransaction?.TrackNew?.CompanyIDOwner ?? 0L,
                railcarLocationTransaction.PreviousTransaction?.TrackNew?.RailDistrict?.CompanyIDOperator ?? 0L,
                railcarLocationTransaction.PreviousTransaction?.TrainNew?.TrainSymbol?.CompanyIDOperator ?? 0L
            }.Where(cID => cID != 0).ToList();

            List<long> allowedGovernmentIDs = new List<long>()
            {
                railcarLocationTransaction.TrackNew?.GovernmentIDOwner ?? 0L,
                railcarLocationTransaction.TrackNew?.RailDistrict?.GovernmentIDOperator ?? 0L,
                railcarLocationTransaction.TrainNew?.TrainSymbol?.GovernmentIDOperator ?? 0L,
                railcarLocationTransaction.PreviousTransaction?.TrackNew?.GovernmentIDOwner ?? 0L,
                railcarLocationTransaction.PreviousTransaction?.TrackNew?.RailDistrict?.GovernmentIDOperator ?? 0L,
                railcarLocationTransaction.PreviousTransaction?.TrainNew?.TrainSymbol?.GovernmentIDOperator ?? 0L
            }.Where(cID => cID != 0).ToList();

            e.IsValid &= allowedCompanyIDs.Contains(this.CompanyID() ?? 0L) || allowedGovernmentIDs.Contains(this.GovernmentID() ?? 0L);
        }

        [HttpGet]
        public async Task<List<RailcarLocationTransaction>> GetByTrain(long? id)
        {
            return new Search<RailcarLocationTransaction>(new LongSearchCondition<RailcarLocationTransaction>()
            {
                Field = "TrainIDNew",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            }).GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByRailcar([FromUri]long? railcarID, [FromUri]int skip = 0, [FromUri]int take = 50)
        {
            if (skip < 0)
            {
                skip = 0;
            }

            if (take < 0)
            {
                take = 50;
            }

            Search<RailcarLocationTransaction> transactionSearch = new Search<RailcarLocationTransaction>(new LongSearchCondition<RailcarLocationTransaction>()
            {
                Field = nameof(RailcarLocationTransaction.RailcarID),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = railcarID
            });
            transactionSearch.SearchOrders.Add(new SearchOrder()
            {
                OrderField = nameof(RailcarLocationTransaction.TransactionTime),
                OrderDirection = SearchOrder.OrderDirections.Descending
            });
            transactionSearch.Skip = skip;
            int remaining = (int)transactionSearch.GetRecordCount() - take;
            if (remaining < 0)
            {
                remaining = 0;
            }

            transactionSearch.Take = take;

            return Ok(new
            {
                remaining,
                railcarLocationTransactions = transactionSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList()
            });
        }
    }
}