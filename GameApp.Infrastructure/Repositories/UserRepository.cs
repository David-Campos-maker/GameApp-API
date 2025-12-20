using System;
using GameApp.Domain.Entities.User;
using GameApp.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace GameApp.Infrastructure.Repositories;

public class UserRepository(UserManager<UserEntity> userManager) : IUserRepository
{
      public async Task<IdentityResult> AddUserRoleAsync(UserEntity entity, string role)
      {
            return await userManager.AddToRoleAsync(entity, role);
      }

      public async Task<IdentityResult> CreateUserAsync(UserEntity entity, string password)
      {
            return await userManager.CreateAsync(entity, password);
      }

      public async Task<IdentityResult> DeleteUserAsync(UserEntity entity)
      {
            return await userManager.DeleteAsync(entity);
      }
}
