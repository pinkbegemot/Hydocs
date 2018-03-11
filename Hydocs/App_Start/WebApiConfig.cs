using System.Web.Http;

namespace Hydocs.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AdWorks",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            //);
            // All routes are displayed in Help Pages, removed 240317

           // config.Routes.MapHttpRoute(
           //name: "ActionApi",
           //routeTemplate: "api/{controller}/{action}"
       );
          
        }
    }
    
}
