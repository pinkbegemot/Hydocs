using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using CPMS.Domain.Requests.Account;
using CPMS.Web.API.GeniusDriver;
using CPMS.Web.API.GeniusDriver.Models;
using MediatR;

namespace CPMS.Web.API.GeniusDriver.Infrastructure
{
    public class JwtAuthenticationMessageHandler : DelegatingHandler
    {
        private readonly IMediator _mediator;

        public JwtAuthenticationMessageHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            //if (request.RequestUri.PathAndQuery.Contains("/Authentication/Logon"))
                //return base.SendAsync(request, cancellationToken);

            var authorization = request.Headers.Authorization;
            
            // No token - just allow this through and fallback onto Authorize and AllowAnonymous tags on the controllers
            if (authorization == null || authorization.Scheme != "Bearer")
                return base.SendAsync(request, cancellationToken);

            if (string.IsNullOrEmpty(authorization.Parameter))
            {
                return CreateUnauthorizedResponse();
            }

            var token = authorization.Parameter;
            var claimsIdentity = AuthenticateJwtToken(token);

            if (claimsIdentity.Result == null)
                return CreateUnauthorizedResponse();


            SetPrincipal(claimsIdentity.Result);

            return base.SendAsync(request, cancellationToken);
        }

        private void SetPrincipal(ClaimsIdentity theUser)
        {
            var roleClaims = theUser.Claims.Where(c => c.Type == theUser.RoleClaimType).ToList();

            var roles = roleClaims.Select(s => s.Value).ToList();
           
            var principal = new GenericPrincipal(theUser, roles.ToArray());

            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private Task<HttpResponseMessage> CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(response);
            return taskCompletionSource.Task;
        }

        protected Task<ClaimsIdentity> AuthenticateJwtToken(string token)
        {
            ClaimsIdentity id;

            if (ValidateToken(token, out id))
            {
                return Task.FromResult(id);
            }

            return Task.FromResult<ClaimsIdentity>(null);
        }

        private bool ValidateToken(string token, out ClaimsIdentity id)
        {
            id = null;

            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;

            if (identity == null)
                return false;
            
            if (!identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);
            var username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            //// More validate to check whether username exists in system
            //var searchDriverRequest = new GetDriverByEmail<DriverName>() {EmailAddress = username, Channel = "Genie"};
            //var result = _mediator.Send(searchDriverRequest);

            //if (result == null) return false;

            id = identity;
            return true;
        }

    }

}