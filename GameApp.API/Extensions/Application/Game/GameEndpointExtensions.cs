using System;
using GameApp.API.Endpoints.Game;
using GameApp.API.Interfaces;

namespace GameApp.API.Extensions.Application.Game;

public static class GameEndpointExtensions
{
      public static void ConfigureGameEndpoints(this WebApplication app)
      {
            var endpoints = app.MapGroup("/");

            endpoints.MapGroup("game/")
                  .WithTags("Game")
                  .MapEndpoint<AddNewGameEndpoint>();
      }
      private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
      {
            TEndpoint.Map(app);
            return app;
      }
}
