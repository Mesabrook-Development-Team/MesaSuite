using API.Common.Attributes;
using API_Company.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebModels.company;

namespace API_Company.Controllers
{
    [MesabrookAuthorization]
    [ImmersibrookAccess]
    public class LocationItemIBAccessController : ApiController
    {
        
    }
}
