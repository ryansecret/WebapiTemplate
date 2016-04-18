using System.Web.Http;

namespace WebApiTemplate
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
               name: "ETaoAPI",
               routeTemplate: "api/{controller}/{action}"
            );

            config.Formatters.JsonFormatter.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        }
    }
}
