namespace GameApp.Application.DTOs.Game;

public record NewGameDto
(
      string Name, 
      DateOnly Published, 
      string Platform, 
      string Gender
);
