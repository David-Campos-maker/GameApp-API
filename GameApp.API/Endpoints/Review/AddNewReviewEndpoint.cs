using System;
using GameApp.API.Interfaces;
using GameApp.Application.DTOs.Review;
using GameApp.Application.Services.Review;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Review;

public class AddNewReviewEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("add-review", 
                  async ([FromServices] IReviewService handler, NewReviewDto request) =>
                  {
                        var result = await handler.CreateReviewAsync(request);
                        if (!result.Succeed) return Results.BadRequest(result.Message);

                        return Results.Ok(result.Message);
                  });
}
