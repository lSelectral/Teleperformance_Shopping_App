using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Teleperformance_Shopping.API.DTOs;
using Teleperformance_Shopping.API.Models;

namespace Teleperformance_Shopping.API.Services.AuthenticationServices
{
    public static class GetJWTSecurityTokenService
    {
        private static List<Claim> GetUserClaim(UserAuthorizationObjectDto user)
        {
            Console.WriteLine(user.Email.Contains("admin") ? "admin" : "user");
            return /*List<Claim> claims =*/ new List<Claim>()
            {
                {new Claim(ClaimTypes.NameIdentifier, user.Email) },
                {new Claim(ClaimTypes.Role, user.Email.ToLower().Contains("admin") ? "admin" : "user") }
            };
        }

        public static ClaimsPrincipal GetClaimsPrincipal(UserAuthorizationObjectDto user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(GetUserClaim(user), JwtBearerDefaults.AuthenticationScheme);
            return new ClaimsPrincipal(identity);
        }

        public static string GetJWTSecurityTokenSerialized(UserAuthorizationObjectDto user, TokenData tokenData)
        {
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: tokenData.Issuer,
                audience: tokenData.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(tokenData.Expiration),
                signingCredentials:
                    new SigningCredentials(new SymmetricSecurityKey
                    (Convert.FromBase64String(tokenData.Key)), SecurityAlgorithms.HmacSha256),
                claims: GetUserClaim(user)
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string accessToken = tokenHandler.WriteToken(token);
            return accessToken;
        }
    }
}