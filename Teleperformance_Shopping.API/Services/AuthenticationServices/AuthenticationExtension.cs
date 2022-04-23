using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Teleperformance_Shopping.API.Models;

namespace Teleperformance_Shopping.API.Services.AuthenticationServices
{
    public static class AuthenticationExtension
    {
        public static void AddJWTAuthenticationValidation(this IServiceCollection services, IConfiguration configuration)
        {
            TokenData tokenOption = configuration.GetSection("TokenOption").Get<TokenData>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    //ValidateAudience = true,            // Validate user 
                    //ValidateIssuer = true,              // Token Provider Validation
                    //ValidateLifetime = true,            // Token expire after specified time
                    //ValidateIssuerSigningKey = true,    // Token encryption key validation
                    ValidIssuer = tokenOption.Issuer,
                    ValidAudience = tokenOption.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(tokenOption.Key)),
                    //ClockSkew = TimeSpan.Zero, // Sets the time difference between different time zones
                };
            });
        }
    }
}