using System;
using Microsoft.AspNetCore.Identity;

namespace GameApp.Domain.Entities.User;

public class UserEntity : IdentityUser<int>
{
      public UserEntity() : base() { }

      public UserEntity(string username, string email) : base()
      {
            UserName = username;
            Email = email;
      }

      public UserPhotoEntity? ProfilePhoto { get; private set; }
}
