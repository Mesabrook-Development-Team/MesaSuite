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
    public class DistributionListController : DataObjectController<DistributionList>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(DistributionList.DistributionListID),
            nameof(DistributionList.DistributionListDomainID),
            nameof(DistributionList.DistributionListAddress),
            nameof(DistributionList.DistributionListRequireAddress),
            nameof(DistributionList.DistributionListMode)
        };

        public override bool AllowGetAll => false;

        public List<DistributionList> GetByDomainName(string domainName)
        {
            Search<DistributionList> dlSearch = new Search<DistributionList>(new StringSearchCondition<DistributionList>()
            {
                Field = "DistributionListDomain.DomainName",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = domainName
            });

            return dlSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}