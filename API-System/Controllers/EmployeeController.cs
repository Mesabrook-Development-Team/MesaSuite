using API.Common;
using API.Common.Attributes;
using API.Common.Extensions;
using ClussPro.ObjectBasedFramework;
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
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Employee.EmployeeID),
            nameof(Employee.CompanyID),
            nameof(Employee.UserID)
        };

        [HttpGet]
        public List<Employee> GetEmployeesByCompany(long companyid)
        {
            Search<Employee> employeeSearch = new Search<Employee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                new LongSearchCondition<Employee>()
                {
                    Field = "CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyid
                },
                new BooleanSearchCondition<Employee>()
                {
                    Field = "ManageEmployees",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = true
                }));

            return employeeSearch.GetReadOnlyReader(null, DefaultRetrievedFields).ToList();
        }

        [HttpPut]
        public IHttpActionResult CreateOrUpdate(Employee employee)
        {
            return SetManageEmployeesFlag(employee, true);
        }

        [HttpPut]
        public IHttpActionResult DemoteEmployee(Employee employee)
        {
            return SetManageEmployeesFlag(employee, false);
        }

        private IHttpActionResult SetManageEmployeesFlag(Employee passedInEmployee, bool manageEmployees)
        {
            Employee dbEmployee;
            if (passedInEmployee.EmployeeID == null || passedInEmployee.EmployeeID == 0)
            {
                Search<Employee> employeeSearch = new Search<Employee>(new SearchConditionGroup(SearchConditionGroup.SearchConditionGroupTypes.And,
                    new LongSearchCondition<Employee>()
                    {
                        Field = "UserID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = passedInEmployee.UserID
                    },
                    new LongSearchCondition<Employee>()
                    {
                        Field = "CompanyID",
                        SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                        Value = passedInEmployee.CompanyID
                    }));

                dbEmployee = employeeSearch.GetEditable();

                if (dbEmployee == null)
                {
                    dbEmployee = DataObjectFactory.Create<Employee>();
                    dbEmployee.UserID = passedInEmployee.UserID;
                    dbEmployee.CompanyID = passedInEmployee.CompanyID;
                }
            }
            else
            {
                dbEmployee = DataObject.GetEditableByPrimaryKey<Employee>(passedInEmployee.EmployeeID, null, null);
            }

            dbEmployee.ManageEmployees = manageEmployees;

            if (!dbEmployee.Save())
            {
                return dbEmployee.HandleFailedValidation(this);
            }

            return Ok(DataObject.GetReadOnlyByPrimaryKey<Employee>(dbEmployee.EmployeeID, null, DefaultRetrievedFields));
        }
    }
}