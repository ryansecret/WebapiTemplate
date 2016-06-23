using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Ryan.Core.Log;

namespace Ryan.Utility
{
    /// <summary>
    ///     错误处理
    /// </summary>
    public class ErrorAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        ///     错误处理
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var url = actionExecutedContext.Request.RequestUri.ToString();
           
            
#if DEBUG
             
            actionExecutedContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(actionExecutedContext.Exception.ToString(), Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.InternalServerError
            };
#else
            actionExecutedContext.Exception.LogError();
            actionExecutedContext.Response = new HttpResponseMessage
            {
                Content = new StringContent("服务器错误", Encoding.UTF8, "application/json"),StatusCode = HttpStatusCode.InternalServerError
            };
#endif
        }
    }
}