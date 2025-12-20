using System;
using GameApp.API.Endpoints.Identity;
using GameApp.API.Interfaces;

namespace GameApp.API.Extensions.Application.Identity;

public static class IdentityEndpointExtensions
{
      public static void ConfigureIdentityEndpoints(this WebApplication app)
      {
            var endpoits = app.MapGroup("/");

            endpoits.MapGroup("identity/")
                  .WithTags("Identity")
                  .MapEndpoint<RegisterUserEndpoint>();
      }

      private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
      {
            TEndpoint.Map(app);
            return app;
      }
}
