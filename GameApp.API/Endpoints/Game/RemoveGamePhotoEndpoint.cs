using System;
using GameApp.API.Interfaces;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class RemoveGamePhotoEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapDelete("remove-game-photo/{id:int}", 
            async ([FromServices] IGameService handler, int id) =>
            {
                  var result = await handler.RemoveGamePhotoAsync(id);
                  if (!result.Succeed) return Results.BadRequest(result.Message);

                  return Results.Ok(result.Data);
            });
}
