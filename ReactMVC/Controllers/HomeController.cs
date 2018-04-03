using System.Collections.Generic;
using System.Web.Mvc;

namespace ReactMVC.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Sets the title and body content (Rss). 
        /// Alternative feed     ///http://vincentaudebert.github.io/feed.xml
        /// </summary>
        /// <returns>The corresponding View</returns>
        public ActionResult Index()
        {
                  
            return View();
        }
        //public ActionResult _IntRss()
        //{
        //    try {
        //        //ViewBag.IntRss = Models.RssReader.GetRssFeeds(" http://feeds.bbci.co.uk/news/rss.xml?edition=int", 65001);
        //        //ViewBag.IntRss = Models.RssReader.GetRssFeeds("https://www.rt.com/rss/", 65001);
        //    }
        //    catch { ViewBag.Title = "Error"; ViewBag.IntRss = "RSS from the specified URL is not available. Sorry about that :-("; }
        //    return PartialView();
        //}
      

        /// <summary>
        ///GET api/values with input params (int id)
        ///</summary>
        //public IEnumerable<Models.RssReader.Rss> Get(string url)
        //{

        //    return Models.RssReader.GetRssFeeds("https://www.rt.com/rss/", 65001) ;
        //}

       
    }

}
