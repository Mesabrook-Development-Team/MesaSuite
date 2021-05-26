using OAuth.App_Code;
using OAuth.Common;
using OAuth.Common.Attributes;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OAuth.Controllers
{
    [AllowedIPsOnly]
    [PresharedAuth]
    public class CheckController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Token(string access_token)
        {
            SecurityProfile profile = await SecurityCache.Get(access_token, true);

            return Json(profile, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Permissions(long? userid)
        {
            if (userid == null)
            {
                return HttpNotFound();
            }

            try
            {
                await SecurityCache.UpdatePermissionsForUserID(userid.Value);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
        }

        [HttpPost]
        public ActionResult UserHasBeenDeleted(long? userid)
        {
            if (userid == null)
            {
                return HttpNotFound();
            }

            try
            {
                SecurityCache.Revoke(userid.Value);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(500);
            }
        }
    }
}
