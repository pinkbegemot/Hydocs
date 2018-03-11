using System.Security.Claims;
using Destructurama.Attributed;
using MediatR;

namespace Hydocs.Areas.AdWorks.Requests {

    /// <summary>
    /// A Request representing log in fields
    /// </summary>
    public class LoginR : IRequest<ClaimsIdentity> {
        public string Username { get; set; }
        [NotLogged]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        //public string ReturnUrl { get; set; }
    }
    
}