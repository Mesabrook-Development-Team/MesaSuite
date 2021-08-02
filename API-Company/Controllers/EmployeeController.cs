using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Web.Http;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    public class EmployeeController : DataObjectController<Employee>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Employee.EmployeeID),
            nameof(Employee.ManageEmails),
            nameof(Employee.ManageEmployees)
        };

        [HttpGet]
        public Employee GetForCompany(long id)
        {
            SecurityProfile securityProfile = Request.Properties["SecurityProfile"] as SecurityProfile;

            Search<Employee> employeeSearch = new Search<Employee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Employee>()
                {
                    Field = "CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = id
                },
                new LongSearchCondition<Employee>()
                {
                    Field = "UserID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = securityProfile.UserID
                }));

            return employeeSearch.GetReadOnly(null, AllowedFields);
        }
    }
}