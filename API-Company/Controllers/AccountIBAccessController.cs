using API.Common.Attributes;
using API.Common.Extensions;
using API_Company.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
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

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    public class AccountIBAccessController : ApiController
    {
        private readonly List<string> AccountFields = FieldPathUtility.CreateFieldPathsAsList<Account>(a => new List<object>()
        {
            a.AccountID,
            a.Description,
            a.AccountNumber,
            a.Balance,
            a.CompanyID,
            a.Company.CompanyID,
            a.Company.Name,
            a.GovernmentID,
            a.Government.GovernmentID,
            a.Government.Name
        });

        public IHttpActionResult GetAccountsForUser()
        {
            if (!Request.Headers.Any(kvp => kvp.Key.Equals("PlayerName", StringComparison.OrdinalIgnoreCase)) || string.IsNullOrEmpty(Request.Headers.GetValues("PlayerName").First()))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            string playerName = Request.Headers.GetValues("PlayerName").First();

            Search<Account> accountSearch = new Search<Account>(new ExistsSearchCondition<Account>()
            {
                RelationshipName = nameof(Account.AccountClearances),
                ExistsType = ExistsSearchCondition<Account>.ExistsTypes.Exists,
                Condition = new StringSearchCondition<AccountClearance>()
                {
                    Field = nameof(AccountClearance.User) + "." + nameof(WebModels.security.User.Username),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = playerName
                }
            });

            return Ok(accountSearch.GetReadOnlyReader(null, AccountFields).OrderBy(a => a.CompanyID == null ? a.Government.Name : a.Company.Name).ThenBy(a => a.Description).ToList());
        }

        public class WithdrawParameter
        {
            public long? AccountID { get; set; }
            public decimal? Amount { get; set; }
        }

        [HttpPost]
        public IHttpActionResult Withdraw(WithdrawParameter parameter)
        {
            if (!Request.Headers.Any(kvp => kvp.Key.Equals("PlayerName", StringComparison.OrdinalIgnoreCase)) || string.IsNullOrEmpty(Request.Headers.GetValues("PlayerName").First()))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            string playerName = Request.Headers.GetValues("PlayerName").First();

            Search<AccountClearance> clearanceCheck = new Search<AccountClearance>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<AccountClearance>()
                {
                    Field = $"{nameof(AccountClearance.User)}.{nameof(WebModels.security.User.Username)}",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = playerName
                },
                new LongSearchCondition<AccountClearance>()
                {
                    Field = nameof(AccountClearance.AccountID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = parameter.AccountID
                }));

            if (!clearanceCheck.ExecuteExists(null))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            Account account = DataObject.GetEditableByPrimaryKey<Account>(parameter.AccountID, null, null);
            if (account.Balance < parameter.Amount)
            {
                account.Errors.AddBaseMessage("Insufficient Funds");
                return account.HandleFailedValidation(this);
            }

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                if (!account.Deposit(-(parameter.Amount ?? 0M), "Withdraw from ATM", transaction))
                {
                    transaction.Rollback();
                    return account.HandleFailedValidation(this);
                }
                else
                {
                    transaction.Commit();
                }
            }

            return Ok();
        }

        public class DepositParameter
        {
            public long? AccountID { get; set; }
            public decimal? Amount { get; set; }
        }

        [HttpPost]
        public IHttpActionResult Deposit(DepositParameter parameter)
        {
            if (!Request.Headers.Any(kvp => kvp.Key.Equals("PlayerName", StringComparison.OrdinalIgnoreCase)) || string.IsNullOrEmpty(Request.Headers.GetValues("PlayerName").First()))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            string playerName = Request.Headers.GetValues("PlayerName").First();

            Search<AccountClearance> clearanceCheck = new Search<AccountClearance>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new StringSearchCondition<AccountClearance>()
                {
                    Field = $"{nameof(AccountClearance.User)}.{nameof(WebModels.security.User.Username)}",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = playerName
                },
                new LongSearchCondition<AccountClearance>()
                {
                    Field = nameof(AccountClearance.AccountID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = parameter.AccountID
                }));

            if (!clearanceCheck.ExecuteExists(null))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            Account account = DataObject.GetEditableByPrimaryKey<Account>(parameter.AccountID, null, null);

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                if (!account.Deposit(parameter.Amount ?? 0M, "Deposit at ATM", transaction))
                {
                    transaction.Rollback();
                    return account.HandleFailedValidation(this);
                }
                else
                {
                    transaction.Commit();
                }
            }

            return Ok();
        }
    }
}
