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
    public class AliasController : DataObjectController<Alias>
    {
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(Alias.AliasID),
            nameof(Alias.AliasDomainID),
            nameof(Alias.AliasName),
            nameof(Alias.AliasValue)
        };

        [HttpGet]
        public List<Alias> GetForDomain(long id)
        {
            Search<Alias> aliases = new Search<Alias>(new LongSearchCondition<Alias>()
            {
                Field = "AliasDomainID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return aliases.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}