using System.Web.Http;
using API.Common.Utility;

namespace API_Government
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new ObjectBasedFrameworkJsonContractResolver();
        }
    }
}
