using System.Web.Http;

namespace API_MCSync.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "MCSyncAPI",
                routeTemplate: "{controller}/{action}",
                defaults: new { action = "Get" });
        }
    }
}