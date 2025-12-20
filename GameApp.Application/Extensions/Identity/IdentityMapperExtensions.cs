using System;
using GameApp.Application.DTOs.Identity;
using GameApp.Domain.Entities.User;

namespace GameApp.Application.Extensions.Identity;

public static class IdentityMapperExtensions
{
      public static UserEntity RegisterDtoToEntity(this RegisterDto dto)
      {
            return new UserEntity
            (
                  dto.UserName, 
                  dto.Email
            );
      }

      public static NewUserDto EntityToNewUserDto(this UserEntity entity, string token)
      {
            return new NewUserDto
            (
                  entity.UserName,
                  entity.Email,
                  token
            );
      }
}
