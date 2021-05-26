using API_User.Attributes;
using System.Web;
using System.Web.Mvc;

namespace API_User
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
