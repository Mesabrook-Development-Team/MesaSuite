using System.Collections.Generic;
using System.Linq;
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
    public class FiscalQuarterController : DataObjectController<FiscalQuarter>
    {
        public override IEnumerable<string> AllowedFields => new string[]
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
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<FiscalQuarter> fiscalQuarterSearch = new Search<FiscalQuarter>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<FiscalQuarter>()
                {
                    Field = "AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = accountID
                },
                new LongSearchCondition<FiscalQuarter>()
                {
                    Field = "Account.CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID
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

            return fiscalQuarterSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}