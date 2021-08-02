using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebModels.company;
using WebModels.hMailServer.dbo;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmails) })]
    public class DomainController : DataObjectController<Domain>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Domain.DomainID),
            nameof(Domain.DomainName)
        };

        public Domain GetByDomainName(string domainName)
        {
            Search<Domain> domainSearch = new Search<Domain>(new StringSearchCondition<Domain>()
            {
                Field = "DomainName",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = domainName
            });

            return domainSearch.GetReadOnly(null, AllowedFields);
        }
    }
}