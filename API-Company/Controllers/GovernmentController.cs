using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using API.Common;
using API.Common.Attributes;
using API_Company.Attributes;
using WebModels.company;
using WebModels.gov;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("company")]
    [CompanyAccess]
    public class GovernmentController : DataObjectController<Government>
    {
        public override IEnumerable<string> DefaultRetrievedFields => new string[]
        {
            nameof(Government.GovernmentID),
            nameof(Government.Name)
        };

        public override bool AllowGetAll => true;

        [NonAction]
        public override Task<Government> Get(long id)
        {
            return Task.FromResult<Government>(null);
        }

        public override Task<IHttpActionResult> Put(Government dataObject)
        {
            return Task.FromResult<IHttpActionResult>(null);
        }

        public override Task<IHttpActionResult> Post(Government dataObject)
        {
            return Task.FromResult<IHttpActionResult>(null);
        }

        public override Task<IHttpActionResult> Patch(PatchData patchData)
        {
            return Task.FromResult<IHttpActionResult>(null);
        }

        public override IHttpActionResult Delete(long id)
        {
            return null;
        }
    }
}