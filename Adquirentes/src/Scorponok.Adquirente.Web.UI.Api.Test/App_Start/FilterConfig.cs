using System.Web;
using System.Web.Mvc;

namespace Scorponok.Adquirente.Web.UI.Api.Test
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
