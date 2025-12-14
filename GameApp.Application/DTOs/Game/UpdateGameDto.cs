namespace GameApp.Application.DTOs.Game;

public record class UpdateGameDto
(
      int Id,
      string? Name,
      DateOnly? Published,
      List<string>? Platforms,
      List<string>? Genders
);
