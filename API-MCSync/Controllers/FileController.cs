using API.Common;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebModels.dbo;

namespace API_MCSync.Controllers
{
    public class FileController : DataObjectController<MCSyncFile>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> AllowedFields => Schema.GetSchemaObject<MCSyncFile>().GetFields().Select(f => f.FieldName);

        [NonAction]
        public override MCSyncFile Get(long id)
        {
            return null;
        }

        [NonAction]
        public override IHttpActionResult Post(MCSyncFile dataObject)
        {
            return null;
        }

        [NonAction]
        public override IHttpActionResult Put(MCSyncFile dataObject)
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
