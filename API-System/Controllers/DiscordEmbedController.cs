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
    public class DiscordEmbedController : DataObjectController<DiscordEmbed>
    {
        public override IEnumerable<string> DefaultRetrievedFields => 
            Schema.GetSchemaObject<DiscordEmbed>().GetFields().Select(f => f.FieldName)
            .Concat(Schema.GetSchemaObject<DiscordEmbedField>().GetFields().Select(f => nameof(DiscordEmbed.DiscordEmbedFields) + "." + f.FieldName));

        /// <summary>
        /// You're doing something wrong if you're calling this.
        /// Retrieve an Embed through a related object rather than be id directly
        /// </summary>
        [NonAction]
        public override Task<DiscordEmbed> Get(long id)
        {
            return null;
        }
    }
}
