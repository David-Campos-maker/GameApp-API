using System;

namespace GameApp.Domain.Entities;

public class GameEntity
{
      private GameEntity() { }

      public GameEntity(string name, DateOnly published, List<string> platforms, List<string> genders, PhotoEntity? coverPhoto = null)
      {
            Name = name;
            Published = published;
            Platforms = platforms;
            Genders = genders;
            CoverPhoto = coverPhoto;
      }

      public GameEntity(string name, DateOnly published, List<string> platforms, List<string> genders)
      {
            Name = name;
            Published = published;
            Platforms = platforms;
            Genders = genders;
      }

      public GameEntity(int id, string name, DateOnly published, List<string> platforms, List<string> genders)
      {
            Id = id;
            Name = name;
            Published = published;
            Platforms = platforms;
            Genders = genders;
      }

      public void SetCoverPhoto(PhotoEntity photo)
      {
            CoverPhoto = photo;
      }

      public void RemoveCoverPhoto()
      {
            CoverPhoto = null;
      }

      public void Update(string? name, DateOnly? published, List<string>? platforms, List<string>? genders)
      {
            Name = name ?? Name;
            Published = published ?? Published;
            Platforms = platforms ?? Platforms;
            Genders = genders ?? Genders;
      }

      public int Id { get; set; }
      public string Name { get; private set; } = string.Empty;
      public PhotoEntity? CoverPhoto { get; private set; }
      public DateOnly Published { get; private set; }
      public List<string> Platforms { get; private set; } = [];
      public List<string> Genders { get; private set; } = [];
      public List<ReviewEntity> Reviews { get; set; } = [];
}
