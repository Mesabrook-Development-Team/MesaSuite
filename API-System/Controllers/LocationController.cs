using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class LocationController : ApiController
    {
        [HttpGet]
        public async Task<List<Location>> GetAllForUser()
        {
            SecurityProfile securityProfile = (SecurityProfile)Request.Properties["SecurityProfile"];
            Search<Location> locationSearch = new Search<Location>(new ExistsSearchCondition<Location>()
            {
                RelationshipName = nameof(Location.LocationEmployees),
                ExistsType = ExistsSearchCondition<Location>.ExistsTypes.Exists,
                Condition = new LongSearchCondition<LocationEmployee>()
                {
                    Field = FieldPathUtility.CreateFieldPathsAsList<LocationEmployee>(le => new List<object>() { le.Employee.UserID }).First(),
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = securityProfile.UserID
                }
            });

            return await Task.Run(() => locationSearch.GetReadOnlyReader(null, FieldPathUtility.CreateFieldPathsAsList<Location>(l => new List<object>()
            {
                l.LocationID,
                l.CompanyID,
                l.Company.CompanyID,
                l.Company.Name,
                l.Name
            })).ToList());
        }
    }
}
