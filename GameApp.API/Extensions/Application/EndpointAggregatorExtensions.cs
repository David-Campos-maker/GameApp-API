using System;
using GameApp.API.Extensions.Application.Game;
using GameApp.API.Extensions.Application.Review;

namespace GameApp.API.Extensions.Application;

public static class EndpointAggregatorExtensions
{
      public static void ConfiguteEndpoints(this WebApplication app)
      {
            app.ConfigureGameEndpoints();
            app.ConfigureReviewEndpoints();
      }
}
