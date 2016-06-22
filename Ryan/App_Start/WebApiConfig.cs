using System;
using System.IO;
using System.Web.Http;
using log4net.Config;
using Ryan.Core.Log;

namespace Ryan
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("WebApi", "api/{controller}/{action}"
                );

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4Net.config");
            XmlConfigurator.ConfigureAndWatch(new FileInfo(path));
           
        }
    }
}