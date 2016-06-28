using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Ryan.Application;
using Ryan.Application.Models;
using Ryan.Core.Intercepters;
using Ryan.Utility;

namespace Ryan.Controller
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
                return new UnauthorizedResult(new [] {new AuthenticationHeaderValue("ryan")},Request);
            }
            return Json(ball);
        }

    }
}