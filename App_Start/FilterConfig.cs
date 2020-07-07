using System.Web;
using System.Web.Mvc;

namespace KT0707NguyenTuanNghia_59131580
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
