using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace CPMS.Web.API.GeniusDriver.Infrastructure
{
    public static class JwtManager
    {
       private const string Secret = "4sejiPOP+/sc8jeUzHsKVXEKW/sdIe2Y3rGN0rxPj10MSZuetpAfeSGcSoXeL6KVZQSehjCmS/0GY8s6h+Gktw==";

        public static string GenerateToken(ClaimsIdentity id, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = id,
                Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                //   { { "alg":"HS256","typ":"JWT"}.{ "nameid":"38e0d89e-426f-6602-f73a-1d3b4ad24801","unique_name":"adam.marshall@chargepointservices.com","http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider":"ASP.NET Identity","email":"adam.marshall@chargepointservices.com","http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid":"38e0d89e-426f-6602-f73a-1d3b4ad24801","given_name":"Adam Marshall","http://schemas.microsoft.com/ws/2008/06/identity/claims/cpms/remember-me":"False","http://schemas.microsoft.com/ws/2008/06/identity/claims/cpms/user-type":"Driver","role":"Driver","nbf":1504878393,"exp":1504921593,"iat":1504878393} }

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(Secret);

                var validationParameters = new TokenValidationParameters()
                {
                   RequireExpirationTime = true,
                   ValidateIssuer = false,
                   ValidateAudience = false,
                  IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                };
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

      
    }
}