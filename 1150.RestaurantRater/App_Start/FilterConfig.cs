using System.Web;
using System.Web.Mvc;

namespace _1150.RestaurantRater
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
