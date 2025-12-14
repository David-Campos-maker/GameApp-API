using System;

namespace GameApp.Domain.Common
{
      public abstract class PhotoEntity
      {
            protected PhotoEntity() { }

            protected PhotoEntity(string url, string publicId)
            {
                  Url = url;
                  PublicId = publicId;
            }

            public int Id { get; set; }
            public string Url { get; private set; } = string.Empty;
            public string? PublicId { get; private set; }
      }
}
