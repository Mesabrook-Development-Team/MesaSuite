using System.Web.Http;

namespace API_CTC.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
    }
}