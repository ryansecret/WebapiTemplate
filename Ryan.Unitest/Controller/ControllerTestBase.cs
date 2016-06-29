using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Microsoft.Practices.ServiceLocation;
using MyTested.WebApi;
using NUnit.Framework;
using Ryan.Core;

namespace Ryan.Unitest.Controller
{
    public class ControllerTestBase<T> where T : ApiController
    {
        protected IControllerBuilder<T> _controller;

        [SetUp]
        public void Initial()
        {
            var containerBuilder = new ContainerBuilder();
            var container = containerBuilder.Build();
            var sl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => sl);
            new RyanWorkEngine(container).Initialize();
        }
    }
}