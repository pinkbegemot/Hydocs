using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeniusAdWorks.App_Start
{
    /// <summary>
    /// TODO:This is for development only and must be removed in Production, TKJ
    ///  </summary>
    /// 
    public class PreflightRequestsHandler : System.Net.Http.DelegatingHandler
    {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                if (request.Headers.Contains("Origin") && request.Method.Method == "OPTIONS")
                {
                    var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                    response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, Accept, Authorization");
                    response.Headers.Add("Access-Control-Allow-Methods", "*");
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    return tsc.Task;
                }

               
            return base.SendAsync(request, cancellationToken);
            }
        }
    
}