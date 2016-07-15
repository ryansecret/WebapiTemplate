using System.Web.Http;
 
using Owin;
using Ryan.Core.Log;
using Ryan.Utility;

namespace Ryan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            ContainerRegister(config, app);
            app.UseWebApi(config);

           
        }
    }
}