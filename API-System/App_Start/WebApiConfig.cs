using System.Web.Http;
using System.Web.Http.Validation;

namespace API_System
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Services.Clear(typeof(ModelValidatorProvider));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "API",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = RouteParameter.Optional }
            );
        }
    }
}
