using API.Common;
using API.Common.Attributes;
using API_System.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess]
    public class EmployeeController : DataObjectController<Employee>
    {
        [HttpGet]
        public List<Employee> GetEmployeesByCompany(long companyid)
        {
            Search<Employee> employeeSearch = new Search<Employee>(new LongSearchCondition<Employee>()
            {
                Field = "CompanyID",
                SearchConditionType = SearchCondition.SearchConditionTypes.Equals,
                Value = companyid
            });

            List<string> fields = Schema.GetSchemaObject<Employee>().GetFields().Select(f => f.FieldName).ToList();
            return employeeSearch.GetReadOnlyReader(null, fields).ToList();
        }
    }
}