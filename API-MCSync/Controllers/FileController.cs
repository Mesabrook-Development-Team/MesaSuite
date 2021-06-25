using ClussPro.ObjectBasedFramework.DataSearch;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.dbo;

namespace API_MCSync.Controllers
{
    public class FileController : ApiController
    {
        // GET: api/File
        public IEnumerable<MCSyncFile> Get()
        {
            Search<MCSyncFile> fileSearch = new Search<MCSyncFile>();
            SchemaObject schemaObject = Schema.GetSchemaObject<MCSyncFile>();
            List<string> fields = schemaObject.GetFields().Select(f => f.FieldName).ToList();

            List<MCSyncFile> files = fileSearch.GetReadOnlyReader(null, fields).ToList();
            return files;
        }
    }
}
