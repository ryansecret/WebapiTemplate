using System.Net.Http;
using Microsoft.Practices.ServiceLocation;
using MyTested.WebApi;
using NUnit.Framework;
using Ryan.Application;
using Ryan.Controller;

namespace Ryan.Unitest.Controller
{
    public class RyanControllerTest : ControllerTestBase<RyanController>
    {
        [SetUp]
        public void TestInit()
        {
            _controller = MyWebApi.Controller<RyanController>().
                WithResolvedDependencyFor(ServiceLocator.Current.GetInstance<RyanApplication>());
        }

        [Test]
        public void GetTest()
        {
            _controller.Calling(d => d.Hello()).ShouldHave().ActionAttributes(attr => attr
                .RestrictingForRequestsWithMethod(HttpMethod.Get));

            _controller.Calling(d => d.Hello())
                .ShouldReturn()
                .Json()
                .WithResponseModelOfType<string>()
                .Passing(d => d == "Hello from ryan");
        }
    }
}