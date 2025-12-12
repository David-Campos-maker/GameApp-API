using System;
using GameApp.API.Interfaces;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class AddGamePhotoEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("add-game-photo/{gameId:int}",
                  async ([FromServices] IGameService handler, int gameId, IFormFile photo) =>
                  {
                        var result = await handler.AddGamePhoto(gameId, photo);
                        if (!result.Succeed) return Results.BadRequest(result.Message);

                        return Results.Ok(result.Message);
                  }
            )
            .DisableAntiforgery();
}
