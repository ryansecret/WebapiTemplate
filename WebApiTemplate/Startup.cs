using System.Web.Http;
using Owin;

namespace WebApiTemplate
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
           

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
