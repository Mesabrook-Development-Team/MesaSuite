using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Linq;
using WebModels.company;
using WebModels.hMailServer.dbo;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmails) })]
    public class DistributionListRecipientController : DataObjectController<DistributionListRecipient>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(DistributionListRecipient.DistributionListRecipientID),
            nameof(DistributionListRecipient.DistributionListRecipientListID),
            nameof(DistributionListRecipient.DistributionListRecipientAddress)
        };

        public override bool AllowGetAll => false;

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