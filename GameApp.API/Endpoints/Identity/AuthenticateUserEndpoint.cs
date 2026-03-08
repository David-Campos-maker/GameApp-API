using System;
using GameApp.API.Interfaces;
using GameApp.Application.DTOs.Identity;
using GameApp.Application.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameApp.API.Endpoints.Identity;

public class AuthenticateUserEndpoint : IEndpoint
{
      public static void Map(IEndpointRouteBuilder app) =>
            app.MapPost("authenticate/" , 
            async([FromServices] IIdentityService handler, AuthenticateUserDto request) =>
            {
                  var result = await handler.AuthenticateUserAsync(request);

                  if(!result.Succeed) return Results.Json(
                        new {message = result.Message},
                        statusCode: 401
                  );

                  return Results.Ok(result.Data);
            });
}
