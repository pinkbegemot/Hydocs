using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Hydocs.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            // routes.EnableFriendlyUrls(settings);
            routes.EnableFriendlyUrls(settings, new HydocsFriendlyURLs()); //TKJ 190517, Mobile switching disabled
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                   defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
    namespaces: new string[] { "Hydocs.Areas.AdWorks.Controllers" } //TKJ 150317
            );
        
        }

    }
    }

