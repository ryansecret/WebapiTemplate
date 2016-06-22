using System.Web.Http;
using Owin;

namespace Ryan
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();


            WebApiConfig.Register(config, app);

            app.UseWebApi(config);
        }
    }
}