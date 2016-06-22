using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using Owin;
using Ryan.Core;


namespace Ryan
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IAppBuilder app)
        {
            config.Routes.MapHttpRoute("WebApi", "api/{controller}/{action}"
                );
            ContainerRegister(config, app);
        }


        public static void ContainerRegister(HttpConfiguration config, IAppBuilder app)
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