using System.Web;
using System.Web.Mvc;

namespace rozproszone_bazy_danych
    {
    public class FilterConfig
        {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
            {
            filters.Add(new HandleErrorAttribute());
            }
        }
    }