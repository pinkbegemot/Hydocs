using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Hydocs.Areas.AdWorks.Requests;
using MediatR;

namespace Hydocs.Areas.AdWorks.Handlers {

    public class LoginH: IRequestHandler<LoginR, ClaimsIdentity>
    {
        private readonly UserManager<User, Guid> _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public LoginH(UserManager userManager, IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _authenticationManager = authenticationManager;
        }

        public ClaimsIdentity Handle(LogOn message)
        {
            var user = _userManager.Find(message.Username, message.Password);

            if (user != null)
            {
                _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                var identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                identity.AddClaim(new Claim(ClaimTypes.Email, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName + " " + user.Surname));
                identity.AddClaim(new Claim(CpmsClaimTypes.RememberMe, message.RememberMe.ToString()));
                identity.AddClaim(new Claim(CpmsClaimTypes.UserType, user.UserType.GetDisplayName()));

                _authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = message.RememberMe }, identity);

                return identity;
            }

            return null;
        }
    }
}