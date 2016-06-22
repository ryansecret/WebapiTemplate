using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using Owin;
using Ryan.Application;
using Ryan.Core;
using Ryan.Model;
using Ryan.Repository;

namespace Ryan
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config,IAppBuilder app)
        {
            config.Routes.MapHttpRoute(
               name: "WebApi",
               routeTemplate: "api/{controller}/{action}"
            );
            ContainerRegister(config,app);
          
        }


        public static void ContainerRegister(HttpConfiguration config,IAppBuilder app)
        {
            var builder = new ContainerBuilder();
 
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
             
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            app.UseAutofacMiddleware(container);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            var sl=new AutofacServiceLocator(container); 
            ServiceLocator.SetLocatorProvider(()=>sl);

            RyanWorkEngine workEngine=new RyanWorkEngine(container);
            workEngine.Initialize();
        }
    }
}
