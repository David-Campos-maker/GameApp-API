using System;

namespace GameApp.Domain.Entities;

public class PhotoEntity
{
      private PhotoEntity() { }

      public PhotoEntity(string url, string publicId)
      {
            Url = url;
            PublicId = publicId;
      }

      public int Id { get; set; }
      public string Url { get; private set; } = string.Empty;
      public string? PublicId { get; private set; }

      public int GameId { get; set; }
      public GameEntity Game { get; set; }
}
