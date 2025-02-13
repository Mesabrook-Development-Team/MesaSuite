using API.Common.Attributes;
using API_System.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    public class BlockAuditIBController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Post(List<BlockAudit> dataObjects)
        {
            List<string> errors = new List<string>();
            foreach(BlockAudit audit in dataObjects)
            {
                if (!await Task.Run(() => audit.Save()))
                {
                    errors.AddRange(audit.Errors.Select(e => e.Message));
                }
            }

            if (errors.Any())
            {
                return new BadRequestErrorMessageResult("The following errors occurred:\r\n\r\n" + string.Join("\r\n", errors), this);
            }
            else
            {
                return Ok();
            }
        }
    }
}
