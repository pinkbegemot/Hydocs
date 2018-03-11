using System.Web.Http;
using System.Web.Mvc;

namespace Hydocs.Areas.React.Controllers
{
    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class RssController : Controller
    {
        private const string ErrorViewName = "Error";

        public RssController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public RssController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
          
            return View();
        }

       

       
    }
}