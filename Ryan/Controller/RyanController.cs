using System.Web.Http;
using Ryan.Application;

namespace Ryan.Controller
{
    public class RyanController : ApiController
    {
        private readonly RyanApplication _ryanApplication;

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