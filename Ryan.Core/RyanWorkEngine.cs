using Autofac;
using Autofac.Extras.DynamicProxy2;
using Daisy.Core;
using LibLog.Example.Library.Logging;
using Ryan.Core.Intercepters;

namespace Ryan.Core
{
    public class RyanWorkEngine : WorkEngine
    {
        private readonly IContainer _containerManager;

        public RyanWorkEngine(IContainer containerManager)
        {
            _containerManager = containerManager;
        }

        public override void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<LogModule>();
                 
            builder.RegisterType<WebAppTypeFinder>().As<ITypeFinder>().SingleInstance();
            builder.Update(_containerManager);
            builder = new ContainerBuilder();
            var typeFinder = _containerManager.Resolve<ITypeFinder>() as AppDomainTypeFinder;
            typeFinder.AssemblyRestrictToLoadingPattern = "^*.Repository|.Application";

            var types = typeFinder.FindClassesEndWith(new[] {"Repository"});
            foreach (var type in types)
            {
                builder.RegisterType(type).AsImplementedInterfaces().SingleInstance();
            }
            types = typeFinder.FindClassesEndWith(new[] {"Application"});
            foreach (var type in types)
            {
                builder.RegisterType(type).EnableClassInterceptors().SingleInstance(); ;
            }
            builder.Update(_containerManager);
        }
    }

    public class LogModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(LogProvider.GetLogger("Logger_Error")).Named<ILog>("Error").SingleInstance();
            builder.RegisterInstance(LogProvider.GetLogger("Logger_Info")).Named<ILog>("Info").SingleInstance();
            
            builder.RegisterType<LogIntercepter>();
        }
    }
}