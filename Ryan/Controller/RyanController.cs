using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac.Extras.DynamicProxy2;
using Autofac.Integration.WebApi;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;
using Ryan.Application;
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
    }
}