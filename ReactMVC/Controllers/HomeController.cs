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
            try
            {
                ViewBag.Title = "News International";
                ViewBag.RssFeed = Models.RssReader.GetRssFeeds("https://www.rt.com/rss/", 65001);
                //ViewBag.RssFeed = Models.RssReader.GetRssFeeds("http://www.fontanka.ru/fontanka.rss", 1251);

            }
            catch (System.Exception e)
            { ViewBag.Title = "Error"; ViewBag.RssFeed = "RSS from one of the specified URLs is not available at the moment. Sorry about that :-(";}
        
            return View();
        }
        public ActionResult _IntRss()
        {
            try {
                ViewBag.IntRss = Models.RssReader.GetRssFeeds(" http://feeds.bbci.co.uk/news/rss.xml?edition=int", 65001);
                //ViewBag.IntRss = Models.RssReader.GetRssFeeds("https://www.rt.com/rss/", 65001);
            }
            catch { ViewBag.Title = "Error"; ViewBag.IntRss = "RSS from the specified URL is not available. Sorry about that :-("; }
            return PartialView();
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        ///GET api/values with input params (int id)
        ///</summary>
        public IEnumerable<Models.RssReader.Rss> Get(string url)
        {

            return Models.RssReader.GetRssFeeds("https://www.rt.com/rss/", 65001) ;
        }

       
    }

}
