using System.Collections.Generic;
using System.Linq;
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
    public class FiscalQuarterController : DataObjectController<FiscalQuarter>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new []
        {
            nameof(FiscalQuarter.FiscalQuarterID),
            nameof(FiscalQuarter.AccountID),
            nameof(FiscalQuarter.Year),
            nameof(FiscalQuarter.Quarter),
            nameof(FiscalQuarter.StartDate),
            nameof(FiscalQuarter.EndDate),
            nameof(FiscalQuarter.StartingBalance),
            nameof(FiscalQuarter.EndingBalance)
        };

        [HttpGet]
        public List<FiscalQuarter> GetForAccount(long accountID)
        {
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());

            Search<FiscalQuarter> fiscalQuarterSearch = new Search<FiscalQuarter>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<FiscalQuarter>()
                {
                    Field = "AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = accountID
                },
                new LongSearchCondition<FiscalQuarter>()
                {
                    Field = "Account.GovernmentID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID
                }))
            {
                SearchOrders = new List<SearchOrder>()
                {
                    new SearchOrder()
                    {
                        OrderField = "Year",
                        OrderDirection = SearchOrder.OrderDirections.Descending
                    },
                    new SearchOrder()
                    {
                        OrderField = "Quarter",
                        OrderDirection = SearchOrder.OrderDirections.Descending
                    }
                }
            };

            return fiscalQuarterSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }
    }
}