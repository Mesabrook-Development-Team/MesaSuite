using OAuth.App_Code;
using API.Common;
using API.Common.Attributes;
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
            SecurityProfile profile = await App_Code.SecurityCache.Get(access_token, true);

            return Json(profile, JsonRequestBehavior.AllowGet);
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
