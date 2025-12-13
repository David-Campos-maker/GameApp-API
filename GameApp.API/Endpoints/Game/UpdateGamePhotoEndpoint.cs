using System;
using GameApp.API.Interfaces;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class UpdateGamePhotoEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPut("update-game-photo/{gameId}",
                  async ([FromServices] IGameService handler, int gameId, IFormFile newPhoto) =>
                  {
                        var result =  await handler.UpdateGamePhotoAsync(gameId, newPhoto);
                        if (!result.Succeed) return Results.BadRequest(result.Message);
                        
                        return Results.Ok(result.Data);
                  })
                  .DisableAntiforgery();
}
