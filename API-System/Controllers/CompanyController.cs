using API.Common;
using API.Common.Attributes;
using API_System.Attributes;
using WebModels.company;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess]
    public class CompanyController : DataObjectController<Company>
    {
        public override bool AllowGetAll => true;
    }
}
