namespace GameApp.Application.DTOs.Identity;

public record class NewUserDto
(
      string UserName,
      string Email,
      string Token
);
