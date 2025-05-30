namespace GameApp.Application.DTOs.Game;

public record GameDto
(
      string Name, 
      DateOnly Published, 
      string Platform, 
      string Gender
);
