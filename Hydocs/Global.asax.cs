using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using Hydocs.App_Start;
using System.Web.Optimization;
using Hydocs.Inrastructure;
using GeniusAdWorks.App_Start;
using System.Web;

namespace Hydocs
{
    public class Global : System.Web.HttpApplication

    {
        void Application_Start()
        {
            // Code that runs on application startup
      
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ReactConfig.Configure();
            AutoMapper.Mapper.Initialize(
                cfg =>
                {
                    cfg.AddProfile<AutoMapperProfile>();
                    //cfg.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
                });

            //GlobalConfiguration.Configuration.MessageHandlers.Add(new PreflightRequestsHandler());
        }

        // TODO: TO WRITE about
        protected void Application_BeginRequest() {
            var res = HttpContext.Current.Response;
            var req = HttpContext.Current.Request;
            // ==== Respond to the OPTIONS verb =====
            if (req.HttpMethod == "OPTIONS")
            {
                res.StatusCode = 200;
                res.End();
            }

        }
    }
}
