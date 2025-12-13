namespace GameApp.Application.DTOs.Review;

public record class ReviewDto
(
      int Id,
      int GameId,
      string Commentary,
      decimal Rate,
      DateTime CreatedDate
);
