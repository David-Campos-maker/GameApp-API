using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using GameApp.Application.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GameApp.Infrastructure.Extensions;

public static class IdentityExtensions
{
      public static IServiceCollection AddSecurityConfig(this IServiceCollection services, IConfiguration config)
      {
            services.AddAuthorization();

            services.AddAuthentication(options =>
            {
                  options.DefaultAuthenticateScheme =
                  options.DefaultChallengeScheme = 
                  options.DefaultForbidScheme =
                  options.DefaultScheme = 
                  options.DefaultSignInScheme =
                  options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                  var jwtSettings = config.GetSection("JWT").Get<JwtSettings>();
                  var key = Encoding.UTF8.GetBytes(jwtSettings?.SigningKey ?? string.Empty);

                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings?.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwtSettings?.Audience,
                        ValidateIssuerSigningKey = true, 
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                  };

                  options.UseSecurityTokenValidators = true;
            });

            return services;
      }
}