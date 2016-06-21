using System.Web.Http;
using Autofac;
using Owin;

namespace Ryan
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

         
            WebApiConfig.Register(config,app);
         
            app.UseWebApi(config);
        }
    }
}
