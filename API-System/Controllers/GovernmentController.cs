using API.Common;
using API.Common.Attributes;
using System.Collections.Generic;
using WebModels.gov;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class GovernmentController : DataObjectController<Government>
    {
        public override bool AllowGetAll => true;

        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Government.GovernmentID),
            nameof(Government.Name),
            nameof(Government.EmailDomain),
            nameof(Government.CanMintCurrency),
            nameof(Government.CanConfigureInterest)
        };
    }
}
