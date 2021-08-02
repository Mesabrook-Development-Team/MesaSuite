using System.Web.Http;
using System.Web.Http.Validation;

namespace API_MCSync.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Clear(typeof(ModelValidatorProvider));

            config.Routes.MapHttpRoute(
                name: "MCSyncAPI",
                routeTemplate: "{controller}/{action}",
                defaults: new { action = "Get" });
        }
    }
}