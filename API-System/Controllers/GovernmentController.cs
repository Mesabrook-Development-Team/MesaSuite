using API.Common;
using API.Common.Attributes;
using API_System.Attributes;
using WebModels.gov;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess]
    public class GovernmentController : DataObjectController<Government>
    {
        public override bool AllowGetAll => true;
    }
}
