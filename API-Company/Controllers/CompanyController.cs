using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    public class CompanyController : DataObjectController<Company>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Company.CompanyID),
            nameof(Company.Name),
            nameof(Company.EmailDomain),
            "Locations.LocationID",
            "Locations.Name"
        };

        [HttpGet]
        public List<Company> GetForEmployee()
        {
            SecurityProfile profile = Request.Properties["SecurityProfile"] as SecurityProfile;

            Search<Employee> employeeSearch = new Search<Employee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Employee>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = profile.UserID
                },
                new ExistsSearchCondition<Employee>()
                {
                    RelationshipName = "Company.Locations.LocationEmployees",
                    ExistsType = ExistsSearchCondition<Employee>.ExistsTypes.Exists,
                    Condition = new LongSearchCondition<LocationEmployee>()
                    {
                        Field = "Employee.UserID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = profile.UserID
                    }
                }));

            List<string> fields = DefaultRetrievedFields.Select(f => $"Company.{f}").ToList();
            fields.AddRange(new string[]
            {
                "Company.Locations.LocationID",
                "Company.Locations.Name"
            });
            return employeeSearch.GetReadOnlyReader(null, fields).Select(e => e.Company).ToList();
        }
    }
}