using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CPMS.Security.Infrastructure;
using System.Net.Http;
using CPMS.Web.API.GeniusDriver.Infrastructure;

namespace CPMS.Web.API.DriverServices.Infrastructure
{
    public class UserIdResolver : ICurrentUserIdResolver
    {
        
        public string GeFtFromToken(HttpRequestMessage request) 
        {
            try
            {
                var headers = request.Headers;

                if (headers.Contains("Authorization"))
                {
                    var token = headers.Authorization.Parameter;
                    //                var token= headers.GetValues("Authorization").First();
                    var principal = JwtManager.GetPrincipal(token);

                    return principal.Claims.First().Value;

                }

                return null;
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Returns a user ID from JWT string sent with every HTTP request
        /// </summary>
        /// <param> name="HttpRequestMessagerequest request"</param>
        /// <returns>Guid id</returns>
        public Guid GetFromToken(HttpRequestMessage request)
        {
            try
            {
                var headers = request.Headers;

                if (headers.Contains("Authorization"))
                {
                    var token= headers.GetValues("Authorization").First();
                    var principal = JwtManager.GetPrincipal(token);
                    return new Guid(principal.Claims.First().Value);
                
                }

               return  Guid.Empty;
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public Guid Get()
        {
//            try
//            {
//                var headers = request.Headers;
//
//                if (headers.Contains("Authorization"))
//                {
//                    var token = headers.GetValues("Authorization").First();
//                    var principal = JwtManager.GetPrincipal(token);
//                    return new Guid(principal.Claims.First().Value);
//
//                }
//
//                return Guid.Empty;
//            }
//            catch
//            {
                return Guid.Empty;
//            }
        }
    }
}
    
