using API_System.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using API.Common.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;
using API.Common.Extensions;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess]
    public class CompanyController : ApiController
    {
        [HttpGet]
        public List<Company> GetCompanies()
        {
            List<string> fields = Schema.GetSchemaObject<Company>().GetFields().Select(f => f.FieldName).ToList();
            return new Search<Company>().GetReadOnlyReader(null, fields).ToList();
        }

        [HttpGet]
        public Company GetCompany(long id)
        {
            List<string> fields = Schema.GetSchemaObject<Company>().GetFields().Select(f => f.FieldName).ToList();
            return DataObject.GetReadOnlyByPrimaryKey<Company>(id, null, fields);
        }

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

        [HttpPost]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (employee.EmployeeID != null && employee.EmployeeID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!employee.Save())
            {
                return employee.HandleFailedValidation(this);
            }

            return Created("GetEmployee?id=" + employee.EmployeeID, employee);
        }

        [HttpPost]
        public IHttpActionResult PostCompany(Company company)
        {
            if (company.CompanyID != null && company.CompanyID != 0)
            {
                return BadRequest("Updates are not allowed with this method");
            }

            if (!company.Save())
            {
                return company.HandleFailedValidation(this);
            }

            return Created("GetCompany?id=" + company.CompanyID, company);
        }

        [HttpPut]
        public IHttpActionResult PutEmployee(Employee employee)
        {
            if (employee.EmployeeID == null || employee.EmployeeID == 0)
            {
                return NotFound();
            }

            Employee dbEmployee = DataObject.GetEditableByPrimaryKey<Employee>(employee.EmployeeID, null, null);
            employee.Copy(dbEmployee);

            if (!dbEmployee.Save())
            {
                return dbEmployee.HandleFailedValidation(this);
            }

            return Ok(dbEmployee);
        }

        [HttpPut]
        public IHttpActionResult PutCompany(Company company)
        {
            if (company.CompanyID == null || company.CompanyID == 0)
            {
                return NotFound();
            }

            Company dbCompany = DataObject.GetEditableByPrimaryKey<Company>(company.CompanyID, null, null);
            company.Copy(dbCompany);

            if (!dbCompany.Save())
            {
                return dbCompany.HandleFailedValidation(this);
            }

            return Ok(dbCompany);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCompany(long id)
        {
            Company company = DataObject.GetEditableByPrimaryKey<Company>(id, null, null);
            if (company == null)
            {
                return NotFound();
            }

            if (!company.Delete())
            {
                return company.HandleFailedValidation(this);
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(long id)
        {
            Employee employee = DataObject.GetEditableByPrimaryKey<Employee>(id, null, null);
            if (employee == null)
            {
                return NotFound();
            }

            if (!employee.Delete())
            {
                return employee.HandleFailedValidation(this);
            }

            return Ok();
        }
    }
}
