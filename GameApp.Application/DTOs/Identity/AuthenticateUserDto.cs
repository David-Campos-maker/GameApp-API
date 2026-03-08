namespace GameApp.Application.DTOs.Identity;

public record class AuthenticateUserDto
(
      string UserName,
      string Password
);
