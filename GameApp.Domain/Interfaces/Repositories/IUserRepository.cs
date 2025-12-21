using System;
using GameApp.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace GameApp.Domain.Interfaces.Repositories;

public interface IUserRepository
{
      Task<IdentityResult> CreateUserAsync(UserEntity entity, string password);
      Task<IdentityResult> AddUserRoleAsync(UserEntity entity, string role);
      Task<IdentityResult> DeleteUserAsync(UserEntity entity);
      Task<UserEntity?> GetUserByUserNameAsync(string userName);
}
