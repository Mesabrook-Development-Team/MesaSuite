using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class BlockAuditAlertConfigBlockController : DataObjectController<BlockAuditAlertConfigBlock>
    {
        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<BlockAuditAlertConfigBlock>().GetFields().Select(f => f.FieldName).ToList();

        public override bool AllowGetAll => true;
    }
}