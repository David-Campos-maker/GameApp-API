using System;
using GameApp.API.Extensions.Application.Game;

namespace GameApp.API.Extensions.Application;

public static class EndpointAggregatorExtensions
{
      public static void ConfiguteEndpoints(this WebApplication app)
      {
            app.ConfigureGameEndpoints();
      }
}
