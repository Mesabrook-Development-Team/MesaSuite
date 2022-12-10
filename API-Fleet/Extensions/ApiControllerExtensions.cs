using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API_Fleet.Extensions
{
    public static class ApiControllerExtensions
    {
        public static long? GovernmentID(this ApiController controller)
        {
            return controller.Request.Headers.Contains("GovernmentID") ? long.Parse(controller.Request.Headers.GetValues("GovernmentID").First()) : (long?)null;
        }

        public static long? CompanyID(this ApiController controller)
        {
            return controller.Request.Headers.Contains("CompanyID") ? long.Parse(controller.Request.Headers.GetValues("CompanyID").First()) : (long?)null;
        }
    }
}