using System;
using System.Net.Http;
using System.Web.Http;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using Ryan.Application;
using Ryan.Core.Intercepters;

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