using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
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
            nameof(Government.Name)
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
    }
}