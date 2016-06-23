using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Ryan.Core;

namespace Ryan.Unitest.Appication
{
    public class ApplicationTestBase
    {
        [SetUp]
        public void PreInital()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            var container = containerBuilder.Build();
            var sl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => sl);
            new RyanWorkEngine(container).Initialize();

        }
    }
}