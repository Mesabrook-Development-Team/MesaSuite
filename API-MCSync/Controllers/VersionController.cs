using API_MCSync.Models.dbo;
using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API_MCSync.Controllers
{
    public class VersionController : ApiController
    {
        public IEnumerable<MCSyncVersion> Get()
        {
            Search<MCSyncVersion> search = new Search<MCSyncVersion>();
            IEnumerable<string> fields = Schema.GetSchemaObject<MCSyncVersion>().GetFields().Select(f => f.FieldName);

            return search.GetReadOnlyReader(null, fields);
        }
    }
}
