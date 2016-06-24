using System.Web.Mvc;
using System.Web.Routing;

namespace Oss
{
    /// <summary>
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/", new {controller = "Home", action = "Index"}
                );
        }
    }
}