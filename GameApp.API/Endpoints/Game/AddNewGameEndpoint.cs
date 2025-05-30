using System;
using GameApp.API.Interfaces;
using GameApp.Application.DTOs.Game;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class AddNewGameEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("add-new-game",
                  async ([FromServices] IGameService handler, NewGameDto request) =>
                  {
                        var result = await handler.AddGameAsync(request);
                        if (!result.Succeed) return Results.BadRequest(result.Message);
                        
                        return Results.Ok(result.Message);
                  });
}
