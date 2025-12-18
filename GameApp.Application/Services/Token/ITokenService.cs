using System;
using GameApp.Domain.Entities.User;

namespace GameApp.Application.Services.Token;

public interface ITokenService
{
      public string CreateToken(UserEntity user);
}
