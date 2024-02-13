using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.account;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new[] { nameof(Official.ManageAccounts) })]
    public class DebitCardController : DataObjectController<DebitCard>
    {
        protected long? GovernmentID => long.Parse(Request.Headers.GetValues("GovernmentID").First());
        public override IEnumerable<string> DefaultRetrievedFields => FieldPathUtility.CreateFieldPathsAsList<DebitCard>(dc => new List<object>()
        {
            dc.DebitCardID,
            dc.AccountID,
            dc.Account.AccountID,
            dc.Account.Description,
            dc.CardNumber,
            dc.IssuedTime,
            dc.UserIDIssuedBy,
            dc.UserIssuedBy.UserID,
            dc.UserIssuedBy.Username
        });

        [NonAction]
        public override Task<IHttpActionResult> Post(DebitCard dataObject)
        {
            return Task.FromResult((IHttpActionResult)new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetForAccount(long? AccountID)
        {
            Search<DebitCard> debitCardSearch = new Search<DebitCard>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<DebitCard>()
                {
                    Field = nameof(DebitCard.AccountID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = AccountID
                },
                new LongSearchCondition<DebitCard>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<DebitCard>(dc => new List<object>() { dc.Account.GovernmentID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                },
                new ExistsSearchCondition<DebitCard>()
                {
                    RelationshipName = FieldPathUtility.CreateFieldPathsAsList<DebitCard>(dc => new List<object>() { dc.Account.AccountClearances }).First(),
                    ExistsType = ExistsSearchCondition<DebitCard>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<AccountClearance>()
                    {
                        Field = nameof(AccountClearance.UserID),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = SecurityProfile.UserID
                    }
                }
            ));

            return Ok(debitCardSearch.GetReadOnlyReader(null, await FieldsToRetrieve()).ToList());
        }
    }
}
