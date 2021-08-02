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
        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Company.CompanyID),
            nameof(Company.Name),
            nameof(Company.EmailDomain)
        };

        [HttpGet]
        public List<Company> GetForEmployee()
        {
            SecurityProfile profile = Request.Properties["SecurityProfile"] as SecurityProfile;

            Search<Employee> employeeSearch = new Search<Employee>(new LongSearchCondition<Employee>()
            {
                Field = "UserID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = profile.UserID
            });

            List<string> fields = AllowedFields.Select(f => $"Company.{f}").ToList();
            return employeeSearch.GetReadOnlyReader(null, fields).Select(e => e.Company).ToList();
        }
    }
}