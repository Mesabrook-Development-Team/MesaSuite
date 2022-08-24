using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;
using WebModels.security;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    public class EmployeeController : DataObjectController<Employee>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Employee.EmployeeID),
            nameof(Employee.CompanyID),
            nameof(Employee.UserID),
            nameof(Employee.EmployeeName),
            nameof(Employee.ManageEmails),
            nameof(Employee.ManageEmployees),
            nameof(Employee.ManageAccounts),
            nameof(Employee.ManageLocations),
            nameof(Employee.IssueWireTransfers)
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

            return employeeSearch.GetReadOnly(null, new List<string>(DefaultRetrievedFields) { nameof(Employee.EmployeeName) });
        }

        [HttpGet]
        [CompanyAccess(OptionalPermissions = new string[] { nameof(Employee.ManageEmployees), nameof(Employee.ManageLocations), nameof(Employee.ManageAccounts) })]
        public List<Employee> GetAllForCompany()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<Employee> employeeSearch = new Search<Employee>(new LongSearchCondition<Employee>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            });

            return employeeSearch.GetReadOnlyReader(null, new List<string>(DefaultRetrievedFields) { nameof(Employee.EmployeeName) }).ToList();
        }

        [HttpPatch]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public async override Task<IHttpActionResult> Patch(PatchData patchData)
        {
            return await base.Patch(patchData);
        }

        [HttpGet]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public List<User> GetCandidates()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<User> userSearch = new Search<User>(new ExistsSearchCondition<User>()
            {
                RelationshipName = "Employees",
                ExistsType = ExistsSearchCondition<User>.ExistsTypes.NotExists,
                Condition = new LongSearchCondition<Employee>()
                {
                    Field = "CompanyID",
                    SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                    Value = companyID
                }
            });

            return userSearch.GetReadOnlyReader(null, new string[] { "UserID", "Username" }).ToList();
        }

        [HttpPut]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public async override Task<IHttpActionResult> Put(Employee dataObject)
        {
            return await base.Put(dataObject);
        }

        [HttpPost]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public async override Task<IHttpActionResult> Post(Employee dataObject)
        {
            return await base.Post(dataObject);
        }
    }
}