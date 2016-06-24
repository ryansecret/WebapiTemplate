using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Ryan;

[assembly: OwinStartup(typeof (Startup))]
namespace Ryan
{
    /// <summary>
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ContainerRegister(GlobalConfiguration.Configuration,app);
        }
    }
}