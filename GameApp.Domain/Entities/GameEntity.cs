using System;

namespace GameApp.Domain.Entities;

public class GameEntity
{
      private GameEntity() { }

      public GameEntity(string name, DateOnly published, string platform, string gender, PhotoEntity? coverPhoto = null)
      {
            Name = name;
            Published = published;
            Platform = platform;
            Gender = gender;
            CoverPhoto = coverPhoto;
      }

      public int Id { get; set; }
      public string Name { get; private set; } = string.Empty;
      public PhotoEntity? CoverPhoto { get; private set; }
      public DateOnly Published { get; private set; }
      public string Platform { get; private set; } = string.Empty;
      public string Gender { get; private set; } = string.Empty;
      public List<ReviewEntity> Reviews { get; set; } = [];
}
