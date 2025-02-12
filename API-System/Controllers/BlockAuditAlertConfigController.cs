using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class BlockAuditAlertConfigController : DataObjectController<BlockAuditAlertConfig>
    {
        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<BlockAuditAlertConfig>().GetFields().Select(f => f.FieldName).Concat(
            Schema.GetSchemaObject<BlockAuditAlertConfigBlock>().GetFields().Select(f => $"{nameof(BlockAuditAlertConfig.BlockAuditAlertConfigBlocks)}.{f.FieldName}"));

        [NonAction]
        public override Task<BlockAuditAlertConfig> Get(long id)
        {
            return null;
        }

        [NonAction]
        public override Task<IHttpActionResult> Post(BlockAuditAlertConfig dataObject)
        {
            return Task.FromResult((IHttpActionResult)new StatusCodeResult(System.Net.HttpStatusCode.Forbidden, this));
        }

        [HttpGet]
        public async Task<BlockAuditAlertConfig> Get()
        {
            return await BlockAuditAlertConfig.GetOrCreate(await FieldsToRetrieve());
        }
    }
}