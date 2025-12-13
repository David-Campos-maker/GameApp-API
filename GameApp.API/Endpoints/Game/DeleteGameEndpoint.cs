using System;
using GameApp.API.Interfaces;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class DeleteGameEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapDelete("delete-game/{id:int}",
                  async ([FromServices] IGameService handler, int id) =>
                  {
                        var result = await handler.DeleteGameAsync(id);
                        if (!result.Succeed) return Results.BadRequest(result.Message);
                        
                        return Results.Ok(result.Message);
                  });
}
