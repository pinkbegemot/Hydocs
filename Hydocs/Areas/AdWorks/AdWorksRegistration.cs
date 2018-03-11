using System.Web.Mvc;

namespace Hydocs.Areas.AdWorks
{
    public class AdWorksRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdWorks";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdWorks_default",
                "AdWorks/{controller}/{action}/{id}",
               new { action = "Index", id = UrlParameter.Optional },
        new { controller = "Customersmv" },
        new[] { "Hydocs.Areas.AdWorks.Controllers" }
            );

           
        }
    }
}