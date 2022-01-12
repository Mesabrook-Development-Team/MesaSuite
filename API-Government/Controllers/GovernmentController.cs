using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(Government.GovernmentID),
            nameof(Government.Name),
            nameof(Government.EmailDomain),
            nameof(Government.CanMintCurrency)
        };

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

            return governmentSearch.GetReadOnlyReader(null, AllowedFields).ToList();
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

            // Validate amounts
            if (parameter.Amount <= 0)
            {
                return BadRequest("Amount must be greater than 0");
            }

            Account account = DataObject.GetEditableByPrimaryKey<Account>(parameter.AccountIDDeposit, null, null);
            if (account == null)
            {
                return BadRequest("Account not found");
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
    }
}