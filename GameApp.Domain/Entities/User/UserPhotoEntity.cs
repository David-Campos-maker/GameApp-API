using System;
using GameApp.Domain.Common;

namespace GameApp.Domain.Entities.User;

public class UserPhotoEntity : PhotoEntity
{
      public UserPhotoEntity() { }

      public UserPhotoEntity(string url, string publicId) : base(url, publicId) { }

      public int UserId { get; private set; }
      public UserEntity User { get; private set; } = null!;

}
