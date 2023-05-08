using System;
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
    [ProgramAccess(new[] { "gov", "company" })]
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
            rlt.TrainNew.TrainFuelRecords.First().TrainFuelRecordID,
            rlt.TrainNew.TrainFuelRecords.First().FuelStart,
            rlt.TrainNew.TrainFuelRecords.First().FuelEnd,
            rlt.TrainNew.TrainDutyTransactions.First().TrainDutyTransactionID,
            rlt.TrainNew.TrainDutyTransactions.First().TimeOnDuty,
            rlt.TrainNew.TrainDutyTransactions.First().TimeOffDuty,
            rlt.PreviousTransaction.TrackIDNew,
            rlt.PreviousTransaction.TrackNew.TrackID,
            rlt.PreviousTransaction.TrackNew.Name,
            rlt.PreviousTransaction.TrainIDNew,
            rlt.PreviousTransaction.TrainNew.TrainID,
            rlt.PreviousTransaction.TrainNew.TrainSymbolID,
            rlt.PreviousTransaction.TrainNew.TrainSymbol.TrainSymbolID,
            rlt.PreviousTransaction.TrainNew.TrainSymbol.Name,
            rlt.PreviousTransaction.TrainNew.TrainFuelRecords.First().TrainFuelRecordID,
            rlt.PreviousTransaction.TrainNew.TrainFuelRecords.First().FuelStart,
            rlt.PreviousTransaction.TrainNew.TrainFuelRecords.First().FuelEnd,
            rlt.PreviousTransaction.TrainNew.TrainDutyTransactions.First().TrainDutyTransactionID,
            rlt.PreviousTransaction.TrainNew.TrainDutyTransactions.First().TimeOnDuty,
            rlt.PreviousTransaction.TrainNew.TrainDutyTransactions.First().TimeOffDuty,
            rlt.NextTransaction.TrackIDNew,
            rlt.NextTransaction.TrackNew.TrackID,
            rlt.NextTransaction.TrackNew.Name,
            rlt.NextTransaction.TrainIDNew,
            rlt.NextTransaction.TrainNew.TrainID,
            rlt.NextTransaction.TrainNew.TrainSymbolID,
            rlt.NextTransaction.TrainNew.TrainSymbol.TrainSymbolID,
            rlt.NextTransaction.TrainNew.TrainSymbol.Name,
            rlt.NextTransaction.TrainNew.TrainFuelRecords.First().TrainFuelRecordID,
            rlt.NextTransaction.TrainNew.TrainFuelRecords.First().FuelStart,
            rlt.NextTransaction.TrainNew.TrainFuelRecords.First().FuelEnd,
            rlt.NextTransaction.TrainNew.TrainDutyTransactions.First().TrainDutyTransactionID,
            rlt.NextTransaction.TrainNew.TrainDutyTransactions.First().TimeOnDuty,
            rlt.NextTransaction.TrainNew.TrainDutyTransactions.First().TimeOffDuty,
            rlt.PossessedByCompany.CompanyID,
            rlt.PossessedByCompany.Name,
            rlt.PossessedByGovernment.GovernmentID,
            rlt.PossessedByGovernment.Name,
            rlt.IsPartialTrainTrip,
            rlt.TransactionTime
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

        [HttpGet]
        public async Task<List<RailcarLocationTransaction>> GetByDates(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null)
            {
                return null;
            }

            Search<RailcarLocationTransaction> transactionSearch = new Search<RailcarLocationTransaction>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new DateTimeSearchCondition<RailcarLocationTransaction>()
                {
                    Field = nameof(RailcarLocationTransaction.TransactionTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.GreaterEquals,
                    Value = startDate
                },
                new DateTimeSearchCondition<RailcarLocationTransaction>()
                {
                    Field = nameof(RailcarLocationTransaction.TransactionTime),
                    SearchConditionType = SearchCondition.SearchConditionTypes.LessEquals,
                    Value = endDate.Value.AddDays(1).AddSeconds(-1)
                },
                new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.Or,
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.PreviousTransaction.TrainNew.TrainSymbol.CompanyIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.CompanyID() == null ? -99 : this.CompanyID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.PreviousTransaction.TrackNew.RailDistrict.CompanyIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.CompanyID() == null ? -99 : this.CompanyID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.TrainNew.TrainSymbol.CompanyIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.CompanyID() == null ? -99 : this.CompanyID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.TrackNew.RailDistrict.CompanyIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.CompanyID() == null ? -99 : this.CompanyID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.PreviousTransaction.TrainNew.TrainSymbol.GovernmentIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.GovernmentID() == null ? -99 : this.GovernmentID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.PreviousTransaction.TrackNew.RailDistrict.GovernmentIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.GovernmentID() == null ? -99 : this.GovernmentID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.TrainNew.TrainSymbol.GovernmentIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.GovernmentID() == null ? -99 : this.GovernmentID()
                    },
                    new LongSearchCondition<RailcarLocationTransaction>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<RailcarLocationTransaction>(rlt => new List<object>() { rlt.TrackNew.RailDistrict.GovernmentIDOperator }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = this.GovernmentID() == null ? -99 : this.GovernmentID()
                    })));

            return transactionSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList();
        }
    }
}