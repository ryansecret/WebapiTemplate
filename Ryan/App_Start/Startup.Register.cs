using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using Owin;
using Ryan.Application;
using Ryan.Controller;
using Ryan.Core;
using Ryan.Core.Intercepters;

namespace Ryan
{
    public partial class Startup
    {
        public void ContainerRegister(HttpConfiguration config, IAppBuilder app)
        {
            var builder = new ContainerBuilder();


            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            app.UseAutofacMiddleware(container);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            var sl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => sl);
           
            var workEngine = new RyanWorkEngine(container);
            workEngine.Initialize();
            
        }
    }
}