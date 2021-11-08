using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WebModels.account;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageAccounts) })]
    public class AccountController : DataObjectController<Account>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Account.AccountID),
            nameof(Account.CompanyID),
            nameof(Account.CategoryID),
            nameof(Account.AccountNumber),
            nameof(Account.Description),
            nameof(Account.Balance)
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

            return accountSearch.GetReadOnlyReader(null, AllowedFields).ToList();
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
    }
}