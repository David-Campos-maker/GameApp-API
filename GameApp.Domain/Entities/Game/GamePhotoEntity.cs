using System;
using GameApp.Domain.Common;

namespace GameApp.Domain.Entities.Game
{
      public class GamePhotoEntity : PhotoEntity
      {
            public GamePhotoEntity (string url, string publicId) : base (url, publicId) { }

            public int GameId { get; private set;}
            public GameEntity Game { get; private set; } = null!;
      }
}
