using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;

namespace Ryan.Utility.ActionFilters
{
    public class LoggingActionFilter : IAutofacActionFilter
    {
        public void OnActionExecuting(HttpActionContext actionContext)
        {
             
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
             
        }
    }
}