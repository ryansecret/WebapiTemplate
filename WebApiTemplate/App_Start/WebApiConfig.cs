using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
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
 
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
             
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            app.UseAutofacMiddleware(container);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            WorkEngine workEngine=new WorkEngine(container);
            workEngine.Initialize();
        }
    }
}
