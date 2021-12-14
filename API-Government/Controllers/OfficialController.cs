using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Government.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.gov;

namespace API_Government.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("gov")]
    [GovernmentAccess(RequiredPermissions = new string[] { nameof(Official.ManageOfficials) })]
    
    public class OfficialController : DataObjectController<Official>
    {
        public override IEnumerable<string> AllowedFields => new string[]
        {
            nameof(Official.OfficialID),
            nameof(Official.GovernmentID),
            nameof(Official.ManageOfficials),
            nameof(Official.ManageEmails)
        };

        [HttpGet]
        public List<Official> GetOfficialsForGovernment(long id)
        {
            Search<Official> officialSearch = new Search<Official>(new LongSearchCondition<Official>()
            {
                Field = "GovernmentID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = id
            });

            return officialSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}