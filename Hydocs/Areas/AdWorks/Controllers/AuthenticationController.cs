using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using MediatR;
using Newtonsoft.Json.Linq;

namespace Hydocs.Areas.AdWorks.Controllers
{
    public class AuthenticationController : ApiController
    {
       

        public AuthenticationController(IMediator mediator)
        {
           
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("login")]
        public IHttpActionResult Login([FromBody] JObject json)
        {
            JToken login, pwd;

            if (json == null) throw new HttpResponseException(HttpStatusCode.BadRequest);
           
            if (!json.TryGetValue("email", out login) || !json.TryGetValue("password", out pwd))
            {
                return BadRequest();
            }

            string email = login.Value<string>();
            string password = pwd.Value<string>();

            var logonRequest = new LogOnDriver()
            {
                Channel = "Genie",
                Username = email,
                Password = password,
                RememberMe = false
            };

            var logonResult = _mediator.Send(logonRequest);

            if (logonResult == null)
            {
                return NotFound();
            }
            
            return Ok(JwtManager.GenerateToken(logonResult, 720));
        }


//        [HttpPost]
//        [AllowAnonymous]
//        [ActionName("scheme")]
//        public IHttpActionResult LoginAddScheme([FromBody] JObject json)
//        {
//            SchemeModel scheme;
//            JToken login;
//            string schemeName;
//
//            try
//            {
//                json.TryGetValue("email", out login);
//                var url = Request.RequestUri;
//                schemeName = getFromUrl(url.ToString());
//                scheme = _mediator.Send(new GetSchemeByName<SchemeModel>
//                {
//                    SchemeName = schemeName
//                });
//
//                var driver =
//                    _mediator.Send(new GetDriverByEmail<DriverModel> { EmailAddress = login.Value<string>(), Channel = "Genie" });
//
//                // Now Add the requested scheme to the driver's scheme membership list
//                var joinSchemeRequest = new DriverJoinScheme
//                {
//                    DriverId = driver.Id,
//                    SchemeId = Guid.Parse(scheme.SchemeId)
//                };
//
//                _mediator.Send(joinSchemeRequest);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest();
//            }
//            return Ok(LogInUser(json, schemeName));
//
//        }

        private string LogInUser(JObject json, string scheme)
        {
            JToken login, pwd;
            if (json.TryGetValue("email", out login) && json.TryGetValue("password", out pwd))
            {
                string email = login.Value<string>();
                string password = pwd.Value<string>();
                var logonRequest = new LogOnDriver()
                {
                    Channel = scheme ?? "Genie",
                    Username = email,
                    Password = password,
                };
                var logonResult = _mediator.Send(logonRequest);

                if (logonResult == null)
                {
                    return null;
                }

                return JwtManager.GenerateToken(logonResult, 720);
            }
            return null;
        }

        private string getFromUrl(string input)
        {
            return input.Split('/').Last();
        }
    }
}