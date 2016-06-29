using System.Web.Mvc;

namespace Ryan
{
    /// <summary>
    /// </summary>
    public class HomeController : Controller
    {
      

        /// <summary>
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public ActionResult Index()
        {
            
            return Content("Ok");
        }
    }
}