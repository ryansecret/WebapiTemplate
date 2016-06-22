using System.Linq;
using System.Text.RegularExpressions;
using Autofac;
using Ryan.Core;

namespace Ryan
{
    public class RyanWorkEngine:WorkEngine
    {
        readonly IContainer _containerManager;
        public RyanWorkEngine(IContainer containerManager)
        {
            _containerManager = containerManager;
        }

        public override void RegisterDependencies()
        { 
            ContainerBuilder builder=new ContainerBuilder();
             
            builder.RegisterType<WebAppTypeFinder>().As<ITypeFinder>().SingleInstance();
            builder.Update(_containerManager);
            builder = new ContainerBuilder();
            var typeFinder = _containerManager.Resolve<ITypeFinder>() as AppDomainTypeFinder;
            typeFinder.AssemblyRestrictToLoadingPattern = "^*.Repository|.Application";
           
            var types = typeFinder.FindClassesEndWith(new[] { "Repository" });
            foreach (var type in types)
            {
                builder.RegisterType(type).AsImplementedInterfaces().SingleInstance();
            }
            
            types = typeFinder.FindClassesEndWith(new[] { "Application" });
            foreach (var type in types)
            {
                builder.RegisterType(type).SingleInstance();
            }
            builder.Update(_containerManager);
        }
    }
}