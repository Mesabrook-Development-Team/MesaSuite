using API.Common.Attributes;
using System.Web.Mvc;

namespace OAuth.Controllers
{
    [AllowedIPsOnly]
    [PresharedAuth]
    public class CheckController : Controller
    {
        [HttpPost]
        public ActionResult UserHasBeenDeleted(long? userid)
        {
            if (userid == null)
            {
                return HttpNotFound();
            }

            try
            {
                App_Code.SecurityCache.Revoke(userid.Value);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
        }
    }
}
