using API.Common;
using System.Web.Http;
using WebModels.dbo;

namespace API_MCSync.Controllers
{
    public class VersionController : DataObjectController<MCSyncVersion>
    {
        public override bool AllowGetAll => true;

        [NonAction]
        public override MCSyncVersion Get(long id)
        {
            return null;
        }

        [NonAction]
        public override IHttpActionResult Post(MCSyncVersion dataObject)
        {
            return null;
        }

        [NonAction]
        public override IHttpActionResult Put(MCSyncVersion dataObject)
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
