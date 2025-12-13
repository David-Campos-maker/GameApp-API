namespace GameApp.Application.DTOs.Game;

public record GameDto
(
      string Name, 
      DateOnly Published, 
      string Platform, 
      List<string> Genders,
      string? CoverPhotoUrl
);
