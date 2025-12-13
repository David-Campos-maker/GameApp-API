namespace GameApp.Application.DTOs.Review;

public record class NewReviewDto
(
      int GameId,
      string Commentary,
      decimal Rate
);
