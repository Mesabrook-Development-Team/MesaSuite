using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageAccounts) })]
    public class TransactionController : DataObjectController<Transaction>
    {
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(Transaction.TransactionID),
            nameof(Transaction.FiscalQuarterID),
            nameof(Transaction.TransactionTime),
            nameof(Transaction.Amount),
            nameof(Transaction.Description)
        };

        [HttpGet]
        public object GetForAccount(long accountID, int skip, int take)
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<Transaction> transactionSearch = new Search<Transaction>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Transaction>()
                {
                    Field = "FiscalQuarter.AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = accountID
                },
                new LongSearchCondition<Transaction>()
                {
                    Field = "FiscalQuarter.Account.CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID
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

            List<Transaction> transactions = transactionSearch.GetReadOnlyReader(null, AllowedFields).ToList();

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