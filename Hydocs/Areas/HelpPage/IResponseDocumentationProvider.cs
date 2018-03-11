using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Hydocs.Areas.HelpPage
{
    interface IResponseDocumentationProvider
    {
      
            string GetResponseDocumentation(HttpActionDescriptor actionDescriptor);
        
    }
}
