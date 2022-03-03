using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;
using WebModels.hMailServer.dbo;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new string[] { nameof(Official.ManageEmails) })]
    public class DistributionListRecipientController : DataObjectController<DistributionListRecipient>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(DistributionListRecipient.DistributionListRecipientID),
            nameof(DistributionListRecipient.DistributionListRecipientListID),
            nameof(DistributionListRecipient.DistributionListRecipientAddress)
        };

        [HttpGet]
        public List<DistributionListRecipient> GetByDistributionListID(int id)
        {
            Search<DistributionListRecipient> recipientSearch = new Search<DistributionListRecipient>(new LongSearchCondition<DistributionListRecipient>()
            {
                Field = "DistributionListRecipientListID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return recipientSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }
    }
}