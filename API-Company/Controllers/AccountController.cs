using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using Newtonsoft.Json;
using WebModels.account;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageAccounts) })]
    public class AccountController : DataObjectController<Account>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Account.AccountID),
            nameof(Account.CompanyID),
            nameof(Account.CategoryID),
            nameof(Account.AccountNumber),
            nameof(Account.Description),
            nameof(Account.Balance)
        };

        protected override IEnumerable<string> RequestableFields => new string[]
        {
            $"{nameof(Account.AccountClearances)}.{nameof(AccountClearance.AccountClearanceID)}",
            $"{nameof(Account.AccountClearances)}.{nameof(AccountClearance.AccountID)}",
            $"{nameof(Account.AccountClearances)}.{nameof(AccountClearance.UserID)}"
        };

        public List<Account> GetForCompany()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<Account> accountSearch = new Search<Account>(new LongSearchCondition<Account>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            });

            return accountSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }

        public class CloseParameter
        {
            public long closingAccountID { get; set; }
            public long destinationAccountID { get; set; }
        }
        [HttpPut]
        public IHttpActionResult Close(CloseParameter closeParameter)
        {
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                Account closingAccount = DataObject.GetEditableByPrimaryKey<Account>(closeParameter.closingAccountID, transaction, null);

                if (!closingAccount.Close(closeParameter.destinationAccountID, transaction))
                {
                    return closingAccount.HandleFailedValidation(this);
                }

                transaction.Commit();

                return Ok();
            }
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
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Account sourceAccount = DataObject.GetEditableByPrimaryKey<Account>(transferParameter.sourceAccountID, null, null);
            Account destinationAccount = DataObject.GetEditableByPrimaryKey<Account>(transferParameter.destinationAccountID, null, null);

            if (sourceAccount.CompanyID != companyID)
            {
                return BadRequest("Source account does not belong to company.");
            }

            if (destinationAccount.CompanyID != companyID)
            {
                return BadRequest("Destination account does not belong to company.");
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                if (!sourceAccount.Transfer(transferParameter.destinationAccountID, transferParameter.amount, transaction))
                {
                    return sourceAccount.HandleFailedValidation(this);
                }

                transaction.Commit();

                return Ok();
            }
        }

        [CompanyAccess]
        
        public List<Account> GetAllForUser()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<Account> accountSearch = new Search<Account>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Account>()
                {
                    Field = "CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID
                },
                new ExistsSearchCondition<Account>()
                {
                    ExistsType = ExistsSearchCondition<Account>.ExistsTypes.Exists,
                    RelationshipName = "AccountClearances",
                    Condition = new LongSearchCondition<AccountClearance>()
                    {
                        Field = "UserID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = SecurityProfile.UserID
                    }
                }));

            return accountSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }
        
        [HttpGet]
        public long[] GetUserIDAccessForAccount(long? id)
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<AccountClearance> accountClearanceSearch = new Search<AccountClearance>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
            new LongSearchCondition<AccountClearance>()
            {
                Field = "AccountID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            },
            new LongSearchCondition<AccountClearance>()
            {
                Field = "Account.CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            }));

            return accountClearanceSearch.GetReadOnlyReader(null, new string[] { "UserID" }).Select(ac => ac.UserID.Value).ToArray();
        }

        [HttpPut]
        public async Task<IHttpActionResult> PutUserIDAccountAccess(long id)
        {
            var param = new { userid = 0L, hasAccess = false };
            param = JsonConvert.DeserializeAnonymousType(await Request.Content.ReadAsStringAsync(), param);

            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<Account> accountSecurityCheckSearch = new Search<Account>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Account>()
                {
                    Field = "AccountID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<Account>()
                {
                    Field = "CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID
                }));

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