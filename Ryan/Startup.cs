using System.Web.Http;
using Common.Logging;
using Microsoft.Practices.ServiceLocation;
using Owin;
using Ryan.Controller;
using Ryan.Core.Log;
using Ryan.Utility;
using LogExtensions = LibLog.Example.Library.Logging.LogExtensions;
using LogProvider = LibLog.Example.Library.Logging.LogProvider;

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
            "adfadf".LogInfo();
            LogExtensions.Info(LogProvider.GetLogger(typeof(RyanController)),"adfadsfsdf");
           // ServiceLocator.Current.GetInstance<ILog>("sfsdf").Info("adfadf");
        }
    }
}