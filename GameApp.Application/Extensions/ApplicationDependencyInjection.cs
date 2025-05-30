using System;
using GameApp.Application.Services.Game;
using GameApp.Application.Services.Photo;
using Microsoft.Extensions.DependencyInjection;

namespace GameApp.Application.Extensions;

public static class ApplicationDependencyInjection
{
      public static IServiceCollection AddApplicationServices(this IServiceCollection services)
      {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IGameService, GameService>();

            return services;
      }
}
