using System;
using GameApp.Application.ApiResults;
using GameApp.Application.Services.Photo;
using GameApp.Domain.Entities.User;
using GameApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GameApp.Application.Services.UserProfile;

public class UserProfileService(IUserRepository userRepository, IPhotoService photoService) : IUserProfileService
{
      public async Task<ApiResult> AddProfilePhotoAsync(int userId, IFormFile photo)
      {
            try
            {
                  var user = await userRepository.GetUserByIdAsync(userId);
                  if (user == null) return ApiResult.Failure("User not found");

                  var folder = "GameApp/Users";

                  var result = await photoService.AddPhotoAsync(photo, folder);
                  if (result.Error != null) return ApiResult.Failure(result.Error.Message);

                  var userPhotoEntity = new UserPhotoEntity
                  (
                        result.SecureUrl.AbsoluteUri,
                        result.PublicId
                  );

                  user.SetProfilePhoto(userPhotoEntity);

                  var updatedUser = await userRepository.UpdateUserAsync(user);

                  if (!updatedUser.Succeeded) 
                        return ApiResult.Failure("Something went wrong while updating the user" + FormatErrors(updatedUser));
                  
                  return ApiResult.Success("Profile photo successfully added");
            }
            catch(Exception ex)
            {
                  return ApiResult.Failure("Something went wrong. " + ex.Message);
            }
      }

      private static string FormatErrors(IdentityResult result) 
            => string.Join(", ", result.Errors.Select(e => e.Description));
}
