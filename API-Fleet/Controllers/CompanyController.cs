using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework;
using ClussPro.ObjectBasedFramework.DataSearch;
using WebModels.company;

namespace API_Fleet.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess(new[] { "gov", "company" })]
    public class CompanyController : ApiController
    {
        private static readonly List<string> CompanyFields = new List<string>()
        {
            nameof(Company.CompanyID),
            nameof(Company.Name)
        };

        [HttpGet]
        public List<Company> GetAll()
        {
            return new Search<Company>().GetReadOnlyReader(null, CompanyFields).ToList();
        }

        [HttpGet]
        public Company Get(long? id)
        {
            return DataObject.GetReadOnlyByPrimaryKey<Company>(id, null, CompanyFields);
        }
    }
}