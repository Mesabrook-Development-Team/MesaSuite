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
    public class AliasController : DataObjectController<Alias>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Alias.AliasID),
            nameof(Alias.AliasDomainID),
            nameof(Alias.AliasName),
            nameof(Alias.AliasValue)
        };

        public override bool AllowGetAll => false;

        public List<Alias> GetByDomainName(string domainName)
        {
            Search<Alias> aliasSearch = new Search<Alias>(new StringSearchCondition<Alias>()
            {
                Field = "AliasDomain.DomainName",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = domainName
            });

            return aliasSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}