using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;
using WebModels.hMailServer.dbo;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new string[] { nameof(Official.ManageEmails) })]
    public class DomainController : DataObjectController<Domain>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(Domain.DomainID),
            nameof(Domain.DomainName)
        };

        [HttpGet]
        public Domain GetForGovernment()
        {
            long governmentID = long.Parse(Request.Headers.GetValues("GovernmentID").First());
            Government government = DataObject.GetReadOnlyByPrimaryKey<Government>(governmentID, null, new string[] { "EmailDomain" });
            if (string.IsNullOrEmpty(government.EmailDomain))
            {
                return null;
            }

            Search<Domain> domainSearch = new Search<Domain>(new StringSearchCondition<Domain>()
            {
                Field = "DomainName",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = government.EmailDomain
            });

            return domainSearch.GetReadOnly(null, DefaultRetrievedFields);
        }
    }
}