using System.Web.Http;

namespace WebApiTemplate.Controller
{
    public class RyanController:ApiController
    {
        [HttpGet]
        public IHttpActionResult Hello()
        {
            return Json("Hello from ryan");
        }
    }
}