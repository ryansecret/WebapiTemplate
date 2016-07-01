using System;
using System.IO;
using System.Web.Http;
using log4net.Config;
using Ryan.Utility;

namespace Ryan
{
    /// <summary>
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}");
            config.Filters.Add(new ErrorAttribute());
            //config.Filters.Add(new ApiAuthorityFilter());

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4Net.config");
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
        }
    }
}