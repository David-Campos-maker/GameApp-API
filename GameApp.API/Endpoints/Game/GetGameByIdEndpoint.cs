using GameApp.API.Interfaces;
using GameApp.Application.Services.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Game;

public class GetGameByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) => 
        app.MapGet("get-game-by-id/{id:int}", 
            async ([FromServices] IGameService handler, int id) =>
            {
                var result = await handler.GetGameByIdAsync(id);
                if (!result.Succeed) return Results.BadRequest(result.Message);

                return Results.Ok(result.Data);
            });
}
