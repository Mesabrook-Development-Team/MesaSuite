using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
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
    public class GovernmentController : DataObjectController<Government>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(Government.GovernmentID),
            nameof(Government.Name),
            nameof(Government.EmailDomain),
            nameof(Government.CanMintCurrency),
            nameof(Government.CanConfigureInterest)
        };

        protected override IEnumerable<string> RequestableFields => new List<string>(DefaultRetrievedFields)
        {
            nameof(Government.InvoiceNumberPrefix),
            nameof(Government.NextInvoiceNumber),
            nameof(Government.EmailImplementationIDPayableInvoice),
            nameof(Government.EmailImplementationIDReadyForReceipt),
            nameof(Government.EmailImplementationIDWireTransferHistory)
        };

        public override bool AllowGetAll => true;

        [HttpGet]
        public List<Government> GetAllForUser()
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"] as SecurityProfile;
            Search<Government> governmentSearch = new Search<Government>(new ExistsSearchCondition<Government>()
            {
                RelationshipName = "Officials",
                ExistsType = ExistsSearchCondition<Government>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<Official>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = securityProfile.UserID
                }
            });

            return governmentSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }

        public class MintCurrencyParameter
        {
            public long AccountIDDeposit { get; set; }
            public decimal Amount { get; set; }
        }
        [HttpPut]
        public IHttpActionResult MintCurrency(MintCurrencyParameter parameter)
        {
            // Check Permissions
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];
            long userID = securityProfile.UserID;

            Government government = DataObject.GetReadOnlyByPrimaryKey<Government>(governmentID, null, new string[] { nameof(Government.CanMintCurrency) });
            if (!government.CanMintCurrency)
            {
                return Unauthorized();
            }

            Official official = new Search<Official>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Official>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = userID
                },
                new LongSearchCondition<Official>()
                {
                    Field = "GovernmentID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = governmentID
                })).GetReadOnly(null, new string[] { nameof(Official.CanMintCurrency) });

            if (!official.CanMintCurrency)
            {
                return Unauthorized();
            }

            Account account = DataObject.GetEditableByPrimaryKey<Account>(parameter.AccountIDDeposit, null, new string[] { "AccountClearances.UserID" });
            if (account == null)
            {
                return BadRequest("Account not found");
            }

            if (!account.AccountClearances.Any(ac => ac.UserID == securityProfile.UserID))
            {
                return Unauthorized();
            }

            // Validate amounts
            if (parameter.Amount <= 0)
            {
                return BadRequest("Amount must be greater than 0");
            }

            // Perform minting process
            using (ITransaction transaction = SQLProviderFactory.GenerateTransaction())
            {
                if (!account.Deposit(parameter.Amount, "New currency minting", transaction))
                {
                    return account.HandleFailedValidation(this);
                }

                transaction.Commit();
            }

            return Ok();
        }

        [HttpPost]
        public override Task<IHttpActionResult> Post(Government government)
        {
            return Task.FromResult<IHttpActionResult>(new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        [HttpPut]
        public override Task<IHttpActionResult> Put(Government dataObject)
        {
            return Task.FromResult<IHttpActionResult>(new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        private readonly List<string> patchableFields = new List<string>()
        {
            nameof(Government.InvoiceNumberPrefix),
            nameof(Government.NextInvoiceNumber)
        };

        [HttpPatch]
        public override Task<IHttpActionResult> Patch(PatchData patchData)
        {
            Dictionary<string, object> replacementValues = new Dictionary<string, object>();
            foreach(KeyValuePair<string, object> kvp in patchData.Values)
            {
                if (patchableFields.Contains(kvp.Key))
                {
                    replacementValues[kvp.Key] = kvp.Value;
                }
            }

            patchData.Values = replacementValues;
            return base.Patch(patchData);
        }
    }
}