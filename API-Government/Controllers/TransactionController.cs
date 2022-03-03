using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new[] { nameof(Official.ManageAccounts) })]
    public class TransactionController : DataObjectController<Transaction>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(Transaction.TransactionID),
            nameof(Transaction.FiscalQuarterID),
            nameof(Transaction.TransactionTime),
            nameof(Transaction.Amount),
            nameof(Transaction.Description)
        };

        public override SearchCondition GetBaseSearchCondition()
        {
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());

            return new LongSearchCondition<Account>()
            {
                Field = "GovernmentID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = governmentID
            };
        }

        [HttpGet]
        public object GetForAccount(long accountID, int skip, int take)
        {
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());

            Search<Transaction> transactionSearch = new Search<Transaction>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Transaction>()
                {
                    Field = "FiscalQuarter.AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = accountID
                },
                new LongSearchCondition<Transaction>()
                {
                    Field = "FiscalQuarter.Account.GovernmentID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID
                }))
            {
                SearchOrders = new List<SearchOrder>()
                {
                    new SearchOrder()
                    {
                        OrderField = "TransactionTime",
                        OrderDirection = SearchOrder.OrderDirections.Descending
                    }
                }
            };

            long transactionCount = transactionSearch.GetRecordCount();

            bool hasPrevious = skip > 0;
            bool hasNext = transactionCount - skip > take;

            transactionSearch.Skip = skip;
            transactionSearch.Take = take;

            List<Transaction> transactions = transactionSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();

            return new
            {
                hasPrevious,
                hasNext,
                transactions,
                transactionCount
            };
        }
    }
}