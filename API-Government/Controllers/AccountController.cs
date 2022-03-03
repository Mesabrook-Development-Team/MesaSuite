using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Government.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using Newtonsoft.Json;
using WebModels.account;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new[] { nameof(Official.ManageAccounts) })]
    public class AccountController : DataObjectController<Account>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(Account.AccountID),
            nameof(Account.GovernmentID),
            nameof(Account.CategoryID),
            nameof(Account.AccountNumber),
            nameof(Account.Description),
            nameof(Account.Balance)
        };

        public override bool AllowGetAll => true;

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
        public class CloseParameter
        {
            public long sourceAccountID { get; set; }
            public long destinationAccountID { get; set; }
        }
        [HttpPut]
        public IHttpActionResult Close(CloseParameter closeParameter)
        {
            Account sourceAccount = DataObject.GetEditableByPrimaryKey<Account>(closeParameter.sourceAccountID, null, null);
            if (sourceAccount == null)
            {
                return NotFound();
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                if (!sourceAccount.Close(closeParameter.destinationAccountID, transaction))
                {
                    transaction.Rollback();
                    return sourceAccount.HandleFailedValidation(this);
                }
                transaction.Commit();
            }

            return Ok();
        }

        public class TransferParameter
        {
            public long sourceAccountID { get; set; }
            public long destinationAccountID { get; set; }
            public decimal amount { get; set; }
        }
        [HttpPut]
        public IHttpActionResult Transfer(TransferParameter transferParameter)
        {
            Account sourceAccount = DataObject.GetEditableByPrimaryKey<Account>(transferParameter.sourceAccountID, null, null);
            if (sourceAccount == null)
            {
                return NotFound();
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                if (!sourceAccount.Transfer(transferParameter.destinationAccountID, transferParameter.amount, transaction))
                {
                    transaction.Rollback();
                    return sourceAccount.HandleFailedValidation(this);
                }

                transaction.Commit();
            }

            return Ok();
        }

        [HttpGet]
        public List<Account> GetAllForCategoryID(long id)
        {
            Search<Account> accountSearch = new Search<Account>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Account>()
                {
                    Field = "CategoryID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                GetBaseSearchCondition()));

            return accountSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }

        [HttpGet]
        public List<Account> MyAccounts()
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];

            Search<Account> accountSearch = new Search<Account>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new ExistsSearchCondition<Account>()
                {
                    ExistsType = ExistsSearchCondition<Account>.ExistsTypes.Exists,
                    RelationshipName = "AccountClearances",
                    Condition = new LongSearchCondition<AccountClearance>()
                    {
                        Field = "UserID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = securityProfile.UserID
                    }
                },
                GetBaseSearchCondition()));
            return accountSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }

        [HttpGet]
        public long[] GetUserIDAccessForAccount(long id)
        {
            Account account = DataObject.GetReadOnlyByPrimaryKey<Account>(id, null, new string[] { "AccountClearances.UserID" });

            return account?.AccountClearances.Where(ac => ac.UserID != null).Select(ac => ac.UserID.Value).ToArray() ?? new long[0];
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutUserIDAccessForAccount(long id)
        {
            var param = new { userid = 0L, hasAccess = false };
            param = JsonConvert.DeserializeAnonymousType(await Request.Content.ReadAsStringAsync(), param);

            Search<Account> accountSecurityCheckSearch = new Search<Account>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Account>()
                {
                    Field = "AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                GetBaseSearchCondition()));

            if (accountSecurityCheckSearch.GetReadOnly(null, new string[] { "AccountID" }) == null)
            {
                return Unauthorized();
            }

            Search<AccountClearance> existingClearanceSearch = new Search<AccountClearance>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<AccountClearance>()
                {
                    Field = "AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<AccountClearance>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = param.userid
                }));

            AccountClearance accountClearance = existingClearanceSearch.GetEditable();
            if (accountClearance == null && !param.hasAccess)
            {
                return Ok();
            }

            if (accountClearance == null)
            {
                accountClearance = DataObjectFactory.Create<AccountClearance>();
                accountClearance.AccountID = id;
                accountClearance.UserID = param.userid;
                if (!accountClearance.Save())
                {
                    return accountClearance.HandleFailedValidation(this);
                }

                return Created($"Account/GetUserIDAccessForAccount/{id}", accountClearance);
            }
            else if (!param.hasAccess)
            {
                if (!accountClearance.Delete())
                {
                    return accountClearance.HandleFailedValidation(this);
                }

                return Ok();
            }
            else
            {
                return Ok(accountClearance);
            }
        }
    }
}