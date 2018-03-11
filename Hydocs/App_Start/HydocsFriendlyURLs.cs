using System;
using System.Web;

namespace Hydocs.App_Start
{
    /// <summary>
    /// This class inherits from WebFormsFriendlyUrlResolver and overrides the default Microsoft behavior of redirecting to Mobile Master page.
    /// Using the functionality requires changes in RouteConfig.cs
    /// </summary>
    public class HydocsFriendlyURLs: Microsoft.AspNet.FriendlyUrls.Resolvers.WebFormsFriendlyUrlResolver
    {
        protected override bool TrySetMobileMasterPage(HttpContextBase httpContext, System.Web.UI.Page page, String mobileSuffix)
        {
            if (mobileSuffix == "Mobile")
            {
                return false;
            }
            else
            {
                return base.TrySetMobileMasterPage(httpContext, page, mobileSuffix);
            }
        }
    }
}