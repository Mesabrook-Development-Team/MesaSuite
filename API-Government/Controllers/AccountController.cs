using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Government.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new[] { nameof(Official.ManageAccounts) })]
    public class AccountController : DataObjectController<Account>
    {
        public override IEnumerable<string> AllowedFields => new[]
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

            return accountSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}