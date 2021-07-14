using API_System.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using OAuth.Common.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.company;

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
    }
}
