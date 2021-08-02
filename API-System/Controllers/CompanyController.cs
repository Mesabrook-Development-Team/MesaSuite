using API.Common;
using API.Common.Attributes;
using System.Collections.Generic;
using WebModels.company;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class CompanyController : DataObjectController<Company>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> AllowedFields => new List<string>()
        {
            nameof(Company.CompanyID),
            nameof(Company.Name),
            nameof(Company.EmailDomain)
        };
    }
}
