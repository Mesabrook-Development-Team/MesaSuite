using API_System.Attributes;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using OAuth.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebModels.gov;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess]
    public class GovernmentController : ApiController
    {
        [HttpGet]
        public List<Government> GetGovernments()
        {
            List<string> fields = Schema.GetSchemaObject<Government>().GetFields().Select(f => f.FieldName).ToList();
            return new Search<Government>().GetReadOnlyReader(null, fields).ToList();
        }
    }
}
