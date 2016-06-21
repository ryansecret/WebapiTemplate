using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using Autofac.Integration.Owin;
using Ryan.Application;

namespace Ryan.Controller
{
    public class RyanController:ApiController
    {
        private RyanApplication _ryanApplication;
        public RyanController(RyanApplication ryanApplication)
        {
            _ryanApplication = ryanApplication;
        }
        [HttpGet]
        public IHttpActionResult Hello()
        {
            return Json(_ryanApplication.Hello());
        }
    }
}