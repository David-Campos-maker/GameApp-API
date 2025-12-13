using System;
using GameApp.API.Endpoints.Review;
using GameApp.API.Interfaces;

namespace GameApp.API.Extensions.Application.Review;

public static class ReviewEndpointExtensions
{
      public static void ConfigureReviewEndpoints(this WebApplication app)
      {
            var endpoints = app.MapGroup("/");

            endpoints.MapGroup("review/")
                  .WithTags("Review")
                  .MapEndpoint<AddNewReviewEndpoint>();
      }

      private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
      {
            TEndpoint.Map(app);
            return app;
      }
}
