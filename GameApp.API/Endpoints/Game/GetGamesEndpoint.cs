using System;
using GameApp.API.Interfaces;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;
using Sprache;

namespace GameApp.API.Endpoints.Game;

public class GetGamesEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapGet("get-games",
                  async ([FromServices] IGameService handler) =>
                  {
                        var result = await handler.GetGamesAsync();

                        if (!result.Succeed) return Results.BadRequest(result.Message);

                        return Results.Ok(result.Data);
                  });
}
