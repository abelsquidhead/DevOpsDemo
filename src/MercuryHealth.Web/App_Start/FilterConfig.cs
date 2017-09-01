using System.Web;
using System.Web.Mvc;

namespace MercuryHealth.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {

            // Default replaced with the override to track unhandled exceptions
            filters.Add(new MecuryHealth.Helper.AiHandleErrorAttribute());
            ////filters.Add(new HandleErrorAttribute());
        }
    }
}
