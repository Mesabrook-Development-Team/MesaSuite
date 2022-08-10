using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using API_Government.Attributes;
using ClussPro.Base.Data;
using ClussPro.Base.Data.Query;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.account;
using WebModels.company;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [GovernmentAccess(RequiredPermissions = new[] { nameof(Official.IssueWireTransfers) })]
    public class WireTransferHistoryController : DataObjectController<WireTransferHistory>
    {
        protected long GovernmentID => long.Parse(Request.Headers.GetValues("GovernmentID").First());

        public override IEnumerable<string> DefaultRetrievedFields => new[]
        {
            nameof(WireTransferHistory.WireTransferHistoryID),
            nameof(WireTransferHistory.GovernmentIDFrom),
            $"{nameof(WireTransferHistory.GovernmentFrom)}.{nameof(Government.GovernmentID)}",
            $"{nameof(WireTransferHistory.GovernmentFrom)}.{nameof(Government.Name)}",
            nameof(WireTransferHistory.CompanyIDFrom),
            $"{nameof(WireTransferHistory.CompanyFrom)}.{nameof(Company.CompanyID)}",
            $"{nameof(WireTransferHistory.CompanyFrom)}.{nameof(Company.Name)}",
            nameof(WireTransferHistory.GovernmentIDTo),
            $"{nameof(WireTransferHistory.GovernmentTo)}.{nameof(Government.GovernmentID)}",
            $"{nameof(WireTransferHistory.GovernmentTo)}.{nameof(Government.Name)}",
            nameof(WireTransferHistory.CompanyIDTo),
            $"{nameof(WireTransferHistory.CompanyTo)}.{nameof(Company.CompanyID)}",
            $"{nameof(WireTransferHistory.CompanyTo)}.{nameof(Company.Name)}",
            nameof(WireTransferHistory.TransferTime),
            nameof(WireTransferHistory.Amount),
            nameof(WireTransferHistory.Memo)
        };

        [HttpGet]
        public override async Task<IHttpActionResult> GetAll()
        {
            Search<WireTransferHistory> originatingWireTransfers = new Search<WireTransferHistory>(new LongSearchCondition<WireTransferHistory>()
            {
                Field = "GovernmentIDFrom",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = GovernmentID
            });

            List<WireTransferHistory> wireTransferHistories = new List<WireTransferHistory>();
            wireTransferHistories.AddRange(originatingWireTransfers.GetReadOnlyReader(null, new List<string>(await FieldsToRetrieve())
            {
                nameof(WireTransferHistory.AccountFromHistorical),
                nameof(WireTransferHistory.AccountToMasked)
            }));

            Search<WireTransferHistory> receivedWireTransfers = new Search<WireTransferHistory>(new LongSearchCondition<WireTransferHistory>()
            {
                Field = "GovernmentIDTo",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = GovernmentID
            });
            wireTransferHistories.AddRange(receivedWireTransfers.GetReadOnlyReader(null, new List<string>(await FieldsToRetrieve())
            {
                nameof(WireTransferHistory.AccountFromMasked),
                nameof(WireTransferHistory.AccountToHistorical)
            }));

            return Ok(wireTransferHistories);
        }

        [HttpGet]
        public override async Task<WireTransferHistory> Get(long id)
        {
            Search<WireTransferHistory> wireTransferSearch = new Search<WireTransferHistory>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<WireTransferHistory>()
                {
                    Field = nameof(WireTransferHistory.WireTransferHistoryID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<WireTransferHistory>()
                {
                    Field = nameof(WireTransferHistory.GovernmentIDFrom),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                }));

            WireTransferHistory wireTransferHistory = wireTransferSearch.GetReadOnly(null, new List<string>(await FieldsToRetrieve())
            {
                nameof(WireTransferHistory.AccountFromHistorical),
                nameof(WireTransferHistory.AccountToMasked)
            });

            if (wireTransferHistory == null)
            {
                wireTransferSearch = new Search<WireTransferHistory>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<WireTransferHistory>()
                {
                    Field = nameof(WireTransferHistory.WireTransferHistoryID),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<WireTransferHistory>()
                {
                    Field = nameof(WireTransferHistory.GovernmentIDTo),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = GovernmentID
                }));

                wireTransferHistory = wireTransferSearch.GetReadOnly(null, new List<string>(await FieldsToRetrieve())
                {
                    nameof(WireTransferHistory.AccountFromMasked),
                    nameof(WireTransferHistory.AccountToHistorical)
                });
            }

            return wireTransferHistory;
        }

        [HttpPut]
        public override Task<IHttpActionResult> Put(WireTransferHistory dataObject)
        {
            return Task.FromResult((IHttpActionResult)new StatusCodeResult(HttpStatusCode.Forbidden, this));
        }

        [HttpPost]
        public override Task<IHttpActionResult> Post(WireTransferHistory dataObject)
        {
            return Task.FromResult((IHttpActionResult)new StatusCodeResult(HttpStatusCode.Forbidden, this));
        }

        [HttpDelete]
        public override IHttpActionResult Delete(long id)
        {
            return new StatusCodeResult(HttpStatusCode.Forbidden, this);
        }

        [HttpPatch]
        public override Task<IHttpActionResult> Patch(PatchData patchData)
        {
            return Task.FromResult((IHttpActionResult)new StatusCodeResult(HttpStatusCode.Forbidden, this));
        }

        [HttpPut]
        public IHttpActionResult PerformWireTransfer(PerformTransferParameter parameter)
        {
            WireTransferHistory history = DataObjectFactory.Create<WireTransferHistory>();

            if (parameter.AccountIDFrom == null)
            {
                history.Errors.Add("AccountFromHistorical", "A valid From Account must be selected.");
                return history.HandleFailedValidation(this);
            }

            Account accountFrom = DataObject.GetEditableByPrimaryKey<Account>(parameter.AccountIDFrom, null, null);

            if (accountFrom == null)
            {
                history.Errors.Add("AccountFromHistorical", "Account From could not be found.");
                return history.HandleFailedValidation(this);
            }

            if (accountFrom.GovernmentID != GovernmentID)
            {
                history.Errors.Add("AccountFromHistorical", "Account From does not belong to this Government.");
                return history.HandleFailedValidation(this);
            }

            if (parameter.AccountTo.Length != 16)
            {
                history.Errors.Add("AccountToMasked", "A valid To Account must be entered.");
                return history.HandleFailedValidation(this);
            }

            if (parameter.AccountTo == null)
            {
                history.Errors.Add("AccountFromHistorical", "Account To is required.");
                return history.HandleFailedValidation(this);
            }

            Account accountTo = new Search<Account>(new StringSearchCondition<Account>()
            {
                Field = nameof(Account.AccountNumber),
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = parameter.AccountTo
            }).GetEditable();

            if (accountTo == null)
            {
                history.Errors.Add("AccountFromHistorical", "Account To could not be found.");
                return history.HandleFailedValidation(this);
            }

            if (string.Equals(parameter.AccountTo, accountFrom.AccountNumber, StringComparison.OrdinalIgnoreCase))
            {
                history.Errors.Add("AccountToMasked", "Wire Transfers From and To the same account are not permitted.");
                return history.HandleFailedValidation(this);
            }

            if (parameter.Amount == null)
            {
                history.Errors.Add("Amount", "A valid amount must be entered.");
                return history.HandleFailedValidation(this);
            }

            if (parameter.Amount < 0)
            {
                history.Errors.Add("Amount", "Transfer amount must be greater than 0.");
                return history.HandleFailedValidation(this);
            }

            if (accountFrom.Balance < parameter.Amount)
            {
                history.Errors.Add("Amount", "You do not have sufficient funds to complete this Wire Transfer.");
                return history.HandleFailedValidation(this);
            }

            string maskedFrom = "XXXXXXXXXXXX" + accountFrom.AccountNumber.Substring(12, 4);
            string maskedTo = "XXXXXXXXXXXX" + accountTo.AccountNumber.Substring(12, 4);

            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                DateTime transferTime = DateTime.Now;
                FiscalQuarter accountFromFiscalQuarter = FiscalQuarter.FindOrCreate(accountFrom.AccountID.Value, transferTime, transaction);
                FiscalQuarter accountToFiscalQuarter = FiscalQuarter.FindOrCreate(accountTo.AccountID.Value, transferTime, transaction);

                Transaction fromTransaction = DataObjectFactory.Create<Transaction>();
                fromTransaction.FiscalQuarterID = accountFromFiscalQuarter.FiscalQuarterID;
                fromTransaction.TransactionTime = transferTime;
                fromTransaction.Description = string.Format(Transaction.DescriptionFormats.WIRE_TRANSFER_OUT, maskedTo);
                fromTransaction.Amount = -parameter.Amount;
                if (!fromTransaction.Save(transaction))
                {
                    return fromTransaction.HandleFailedValidation(this);
                }

                Transaction toTransaction = DataObjectFactory.Create<Transaction>();
                toTransaction.FiscalQuarterID = accountToFiscalQuarter.FiscalQuarterID;
                toTransaction.TransactionTime = transferTime;
                toTransaction.Description = string.Format(Transaction.DescriptionFormats.WIRE_TRANSFER_IN, maskedFrom);
                toTransaction.Amount = parameter.Amount;
                if (!toTransaction.Save(transaction))
                {
                    return toTransaction.HandleFailedValidation(this);
                }

                accountFrom.Balance -= parameter.Amount;
                if (!accountFrom.Save(transaction))
                {
                    return accountFrom.HandleFailedValidation(this);
                }

                accountTo.Balance += parameter.Amount;
                if (!accountTo.Save(transaction))
                {
                    return accountTo.HandleFailedValidation(this);
                }

                WireTransferHistory wireTransfer = DataObjectFactory.Create<WireTransferHistory>();
                wireTransfer.GovernmentIDFrom = GovernmentID;
                wireTransfer.CompanyIDTo = accountTo.CompanyID;
                wireTransfer.GovernmentIDTo = accountTo.GovernmentID;
                wireTransfer.AccountFromHistorical = $"{accountFrom.Description} ({accountFrom.AccountNumber})";
                wireTransfer.AccountFromMasked = maskedFrom;
                wireTransfer.AccountToHistorical = $"{accountTo.Description} ({accountTo.AccountNumber})";
                wireTransfer.AccountToMasked = maskedTo;
                wireTransfer.TransferTime = transferTime;
                wireTransfer.Amount = parameter.Amount;
                wireTransfer.Memo = parameter.Memo;
                if (!wireTransfer.Save(transaction))
                {
                    return wireTransfer.HandleFailedValidation(this);
                }

                transaction.Commit();
            }

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult SetWireTransferEmailImplementationID(long id)
        {
            Government government = DataObject.GetEditableByPrimaryKey<Government>(GovernmentID, null, null);
            government.EmailImplementationIDWireTransferHistory = id == -1L ? (long?)null : id;
            if (!government.Save())
            {
                return government.HandleFailedValidation(this);
            }

            return Ok();
        }

        public class PerformTransferParameter
        {
            public long? AccountIDFrom { get; set; }
            public string AccountTo { get; set; }
            public decimal? Amount { get; set; }
            public string Memo { get; set; }
        }
    }
}