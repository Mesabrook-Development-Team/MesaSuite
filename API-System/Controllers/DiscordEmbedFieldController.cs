using API.Common;
using API.Common.Attributes;
using ClussPro.ObjectBasedFramework.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.mesasys;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    public class DiscordEmbedFieldController : DataObjectController<DiscordEmbedField>
    {
        public override IEnumerable<string> DefaultRetrievedFields => Schema.GetSchemaObject<DiscordEmbedField>().GetFields().Select(f => f.FieldName);

        /// <summary>
        /// You're doing something wrong if you're calling this.
        /// Retrieve an Embed Field through a related object rather than be id directly
        /// </summary>
        [NonAction]
        public override Task<DiscordEmbedField> Get(long id)
        {
            return null;
        }
    }
}
