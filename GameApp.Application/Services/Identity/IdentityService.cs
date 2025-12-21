using System;
using GameApp.Application.ApiResults;
using GameApp.Application.DTOs.Identity;
using GameApp.Application.Extensions.Identity;
using GameApp.Application.Services.Token;
using GameApp.Domain.Entities.User;
using GameApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GameApp.Application.Services.Identity;

public class IdentityService
(
      IUserRepository userRepository,
      SignInManager<UserEntity> signInManager,
      ITokenService tokenService
) : IIdentityService
{
      public async Task<ApiResult<NewUserDto>> AuthenticateUserAsync(AuthenticateUserDto request)
      {
            var user = await userRepository.GetUserByUserNameAsync(request.UserName);

            if (user == null)
                  return ApiResult<NewUserDto>.Failure("User not found");

            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                  return ApiResult<NewUserDto>.Failure("Invalid credentials");

            return ApiResult<NewUserDto>.Success(user.EntityToNewUserDto(tokenService.CreateToken(user)));
      }

      public async Task<ApiResult<NewUserDto>> RegisterUserAsync(RegisterDto request)
      {
            try
            {
                  var user = request.RegisterDtoToEntity();

                  var creationResult = await userRepository.CreateUserAsync(user, request.Password);

                  if (!creationResult.Succeeded)
                        return ApiResult<NewUserDto>.Failure("User create failed: " + FormatErrors(creationResult));

                  var roleResult = await userRepository.AddUserRoleAsync(user, "User");

                  if (!roleResult.Succeeded)
                  {
                        await userRepository.DeleteUserAsync(user);
                        return ApiResult<NewUserDto>.Failure("User creation rolled back: " + FormatErrors(roleResult));
                  }

                  var token = tokenService.CreateToken(user);

                  return ApiResult<NewUserDto>.Success(user.EntityToNewUserDto(token));
            }
            catch (Exception ex)
            {
                  return ApiResult<NewUserDto>.Failure("Something went wrong " + ex.Message);
            }
      }
      
      private static string FormatErrors(IdentityResult result) 
            => string.Join(", ", result.Errors.Select(e => e.Description));
}
