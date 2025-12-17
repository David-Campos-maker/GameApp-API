using System;
using Microsoft.AspNetCore.Identity;

namespace GameApp.Domain.Entities.User;

public class UserEntity : IdentityUser<int>
{
      public UserPhotoEntity? ProfilePhoto { get; private set; }
}
