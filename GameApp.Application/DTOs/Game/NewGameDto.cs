namespace GameApp.Application.DTOs.Game;

public record NewGameDto
(
      string Name, 
      DateOnly Published, 
      List<string> Platforms, 
      List<string> Genders
);
