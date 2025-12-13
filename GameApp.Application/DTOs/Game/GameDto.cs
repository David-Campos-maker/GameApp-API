using GameApp.Application.DTOs.Review;

namespace GameApp.Application.DTOs.Game;

public record GameDto
(
      int Id,
      string Name, 
      DateOnly Published, 
      string Platform, 
      List<string> Genders,
      string? CoverPhotoUrl,
      List<ReviewDto> Reviews
);
