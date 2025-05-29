using System;

namespace GameApp.Domain.Entities;

public class ReviewEntity
{
      private ReviewEntity() { }

      public ReviewEntity(decimal rate, string commentary)
      {
            Rate = rate;
            Commentary = commentary;
            CreatedDate = DateTime.Now;
      }

      public int Id { get; set; }
      public decimal Rate { get; private set; }
      public string Commentary { get; private set; } = string.Empty;
      public DateTime CreatedDate { get; private set; }

      public int GameId { get; set; }
      public GameEntity Game { get; set; }
}
