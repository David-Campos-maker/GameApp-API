using GameApp.Application.DTOs.Review;

namespace GameApp.Application.DTOs.Game;

public record GameDto
(
      int Id,
      string Name, 
      DateOnly Published, 
      List<string> Platforms, 
      List<string> Genders,
      string? CoverPhotoUrl,
      List<ReviewDto> Reviews
);
