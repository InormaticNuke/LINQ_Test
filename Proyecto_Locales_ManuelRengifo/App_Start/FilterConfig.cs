using System.Web;
using System.Web.Mvc;

namespace Proyecto_Locales_ManuelRengifo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
