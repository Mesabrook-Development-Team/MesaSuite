using API.Common;
using API.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebModels.hMailServer.dbo;

namespace API_System.Controllers
{
    [MesabrookAuthorization]
    [ProgramAccess("system")]
    public class DomainController : DataObjectController<Domain>
    {
        public override bool AllowGetAll => true;
        public override IEnumerable<string> DefaultRetrievedFields => new List<string>()
        {
            nameof(Domain.DomainID),
            nameof(Domain.DomainName)
        };
    }
}