using System.Web.Http;
using Ryan.Application;

namespace Ryan.Controllers
{
    
    
    public class RyanController : BaseController
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