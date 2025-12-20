using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Identity;

namespace GameApp.Application.Services.Identity;

public interface IIdentityService
{
      public Task<ApiResult<NewUserDto>> RegisterUserAsync(RegisterDto request);
}
