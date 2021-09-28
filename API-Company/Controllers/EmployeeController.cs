using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;
using WebModels.security;

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

            return employeeSearch.GetReadOnly(null, new List<string>(AllowedFields) { nameof(Employee.EmployeeName) });
        }

        [HttpGet]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public List<Employee> GetAllForCompany()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            Search<Employee> employeeSearch = new Search<Employee>(new LongSearchCondition<Employee>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyID
            });

            return employeeSearch.GetReadOnlyReader(null, new List<string>(AllowedFields) { nameof(Employee.EmployeeName) }).ToList();
        }

        [HttpPatch]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public override IHttpActionResult Patch(PatchData patchData)
        {
            return base.Patch(patchData);
        }

        [HttpGet]
        [CompanyAccess(RequiredPermissions = new string[] { nameof(Employee.ManageEmployees) })]
        public List<User> GetCandidates()
        {
            long companyID = long.Parse(Request.Headers.GetValues("CompanyID").First());

            
        }
    }
}