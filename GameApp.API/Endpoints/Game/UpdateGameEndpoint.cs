using System;
using GameApp.API.Interfaces;
using GameApp.Application.DTOs.Game;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class UpdateGameEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("update-game" , 
            async ([FromServices] IGameService handler, UpdateGameDto request) =>
            {
                  var result = await handler.UpdateGameAsync(request);

                  if (!result.Succeed) return Results.BadRequest(result.Message);

                  return Results.Ok(result.Data);
            });
}
