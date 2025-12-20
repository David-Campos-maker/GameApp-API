using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameApp.Application.Helpers;
using GameApp.Domain.Entities.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GameApp.Application.Services.Token;

public class TokenService(IOptions<JwtSettings> config) : ITokenService
{
      private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(config.Value.SigningKey));

      public string CreateToken(UserEntity user)
      {
            var claims = new List<Claim>
            {
                  new(JwtRegisteredClaimNames.Email, user.Email),
                  new(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                  Subject = new ClaimsIdentity(claims),
                  Expires = DateTime.Now.AddDays(7),
                  SigningCredentials = credentials,
                  Issuer = config.Value.Issuer,
                  Audience = config.Value.Audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
      }
}
