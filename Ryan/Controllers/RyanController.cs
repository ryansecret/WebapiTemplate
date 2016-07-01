using System.Net.Http;
using System.Web.Http;
using Ryan.Application;
using Ryan.Application.Models;

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

        [HttpPost]
        public IHttpActionResult KickBall(Ball ball)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            return Ok(ball);
        } 
        [HttpPost]
        public Ball RyanTest([FromBody]string g)
        {
            return new Ball() {Color = "ryan",Name = "chen"};
        }
    }
}