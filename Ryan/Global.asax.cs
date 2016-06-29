﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ryan
{
    /// <summary>
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
        }
 
    }
}