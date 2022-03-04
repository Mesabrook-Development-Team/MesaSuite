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
    public class DistributionListController : DataObjectController<DistributionList>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(DistributionList.DistributionListID),
            nameof(DistributionList.DistributionListDomainID),
            nameof(DistributionList.DistributionListAddress),
            nameof(DistributionList.DistributionListRequireAddress),
            nameof(DistributionList.DistributionListMode)
        };

        [HttpGet]
        public List<DistributionList> GetByDomainName(string domainName)
        {
            Search<DistributionList> dlSearch = new Search<DistributionList>(new StringSearchCondition<DistributionList>()
            {
                Field = "DistributionListDomain.DomainName",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = domainName
            });

            return dlSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }
    }
}
