using System;
using GameApp.Application.ApiResults;
using Microsoft.AspNetCore.Http;

namespace GameApp.Application.Services.UserProfile;

public interface IUserProfileService
{
      Task<ApiResult> AddProfilePhotoAsync(int userId, IFormFile photo);
}
