using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class EmployeeController : DataObjectController<Employee>
    {
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Employee.EmployeeID),
            nameof(Employee.CompanyID),
            nameof(Employee.UserID),
            nameof(Employee.ManageEmails),
            nameof(Employee.ManageEmployees)
        };

        [HttpGet]
        public List<Employee> GetEmployeesByCompany(long companyid)
        {
            Search<Employee> employeeSearch = new Search<Employee>(new LongSearchCondition<Employee>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyid
            });

            return employeeSearch.GetReadOnlyReader(null, AllowedFields).ToList();
        }
    }
}