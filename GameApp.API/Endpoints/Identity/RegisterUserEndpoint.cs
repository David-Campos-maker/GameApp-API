using System;
using GameApp.API.Interfaces;
using GameApp.Application.DTOs.Identity;
using GameApp.Application.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Identity;

public class RegisterUserEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("register-user/" ,
                  async([FromServices] IIdentityService handler, RegisterDto request) =>
                  {
                        var result = await handler.RegisterUserAsync(request);

                        if (!result.Succeed) return Results.BadRequest(result.Message);

                        return Results.Ok(result.Data);
                  });
}
