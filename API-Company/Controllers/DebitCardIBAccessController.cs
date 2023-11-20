using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.account;
using ClussPro.ObjectBasedFramework;
using WebModels.security;
using API.Common.Extensions;
using ClussPro.Base.Data.Query;
using ClussPro.Base.Data;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    public class DebitCardIBAccessController : ApiController
    {
        [HttpPost]
        public IHttpActionResult IssueDebitCard(IssueDebitCardParameter parameter)
        {
            if (!Request.Headers.Any(kvp => kvp.Key.Equals("PlayerName", StringComparison.OrdinalIgnoreCase)) || string.IsNullOrEmpty(Request.Headers.GetValues("PlayerName").First()))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            string playerName = Request.Headers.GetValues("PlayerName").First();

            Search<Account> accountSecurityCheck = new Search<Account>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Account>()
                {
                    Field = nameof(Account.AccountID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = parameter.AccountID
                },
                new ExistsSearchCondition<Account>()
                {
                    RelationshipName = nameof(Account.AccountClearances),
                    ExistsType = ExistsSearchCondition<Account>.ExistsTypes.Exists,
                    Condition = new StringSearchCondition<AccountClearance>()
                    {
                        Field = FieldPathUtility.CreateFieldPathsAsList<AccountClearance>(ac => new List<object>() { ac.User.Username }).First(),
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = playerName
                    }
                }));

            if (!accountSecurityCheck.ExecuteExists(null))
            {
                return new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this);
            }

            if (string.IsNullOrEmpty(parameter.PIN) || parameter.PIN.Length != 4 || !short.TryParse(parameter.PIN, out short shrtPIN))
            {
                return new BadRequestErrorMessageResult("PIN must be 4 digits", this);
            }

            string newCardNumber;
            Search<DebitCard> existsSearch;
            Random random = new Random();

            do
            {
                newCardNumber = string.Empty;
                for(int i = 0; i < 16; i++)
                {
                    int randomNumber = random.Next(0, 10);
                    if (randomNumber == 0 && i == 0)
                    {
                        i--;
                        continue;
                    }

                    newCardNumber += randomNumber.ToString();
                }

                existsSearch = new Search<DebitCard>(new StringSearchCondition<DebitCard>()
                {
                    Field = nameof(DebitCard.CardNumber),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = newCardNumber
                });
            }
            while (existsSearch.ExecuteExists(null));

            User user = new Search<User>(new StringSearchCondition<User>() { Field = nameof(WebModels.security.User.Username), SearchConditionType = SearchCondition.SearchConditionTypes.Equals, Value = playerName }).GetReadOnly(null, new[] { nameof(WebModels.security.User.UserID) });
            DebitCard debitCard;
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                debitCard = DataObjectFactory.Create<DebitCard>();
                debitCard.AccountID = parameter.AccountID;
                debitCard.CardNumber = newCardNumber;
                debitCard.IssuedTime = DateTime.Now;
                debitCard.Pin = shrtPIN;
                debitCard.UserIDIssuedBy = user.UserID;
                if (!debitCard.Save(transaction))
                {
                    return debitCard.HandleFailedValidation(this);
                }

                if (!string.IsNullOrEmpty(parameter.CardFeeAccount) && parameter.CardFeeAmount > 0)
                {
                    Account sourceAccount = DataObject.GetEditableByPrimaryKey<Account>(parameter.AccountID, null, null);

                    if (sourceAccount.Balance < parameter.CardFeeAmount)
                    {
                        return new BadRequestErrorMessageResult("Insufficient Funds", this);
                    }

                    Search<Account> feeAccountSearch = new Search<Account>(new StringSearchCondition<Account>() { Field = nameof(Account.AccountNumber), SearchConditionType = SearchCondition.SearchConditionTypes.Equals, Value = parameter.CardFeeAccount });
                    Account feeAccount = feeAccountSearch.GetEditable();

                    if (sourceAccount != null || feeAccount != null)
                    {
                        if (!sourceAccount.Deposit(-parameter.CardFeeAmount.Value, "New Debit Card Fee", transaction))
                        {
                            return sourceAccount.HandleFailedValidation(this);
                        }

                        if (!feeAccount.Deposit(parameter.CardFeeAmount.Value, "New Debit Card Fee Revenue", transaction))
                        {
                            return feeAccount.HandleFailedValidation(this);
                        }
                    }
                }

                transaction.Commit();
            }

            DebitCard savedCard = DataObject.GetReadOnlyByPrimaryKey<DebitCard>(debitCard.DebitCardID, null, FieldPathUtility.CreateFieldPathsAsList<DebitCard>(dc => new List<object>()
            {
                dc.DebitCardID,
                dc.AccountID,
                dc.Account.AccountID,
                dc.Account.Description,
                dc.Account.CompanyID,
                dc.Account.GovernmentID,
                dc.CardNumber,
                dc.IssuedTime,
                dc.UserIDIssuedBy,
                dc.UserIssuedBy.UserID,
                dc.UserIssuedBy.Username
            }));

            return Ok(savedCard);
        }

        public class IssueDebitCardParameter
        {
            public long? AccountID;
            public string PIN;
            public string CardFeeAccount;
            public decimal? CardFeeAmount;
        }
    }
}
