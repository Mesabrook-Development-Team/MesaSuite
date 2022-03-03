using API.Common;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.dbo;

namespace API_MCSync.Controllers
{
    public class FileController : DataObjectController<MCSyncFile>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<MCSyncFile>().GetFields().Select(f => f.FieldName);

        [NonAction]
        public async override Task<MCSyncFile> Get(long id)
        {
            return null;
        }

        [NonAction]
        public async override Task<IHttpActionResult> Post(MCSyncFile dataObject)
        {
            return null;
        }

        [NonAction]
        public async override Task<IHttpActionResult> Put(MCSyncFile dataObject)
        {
            return null;
        }

        [NonAction]
        public override IHttpActionResult Delete(long id)
        {
            return null;
        }
    }
}
