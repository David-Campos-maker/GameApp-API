namespace GameApp.Application.DTOs.Game;

public record class UpdateGameDto
(
      int Id,
      string? Name,
      DateOnly? Published,
      string? Platform,
      List<string>? Genders
);
