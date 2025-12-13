using System;
using GameApp.Application.Helpers;
using GameApp.Application.Services.Game;
using GameApp.Application.Services.Photo;
using GameApp.Application.Services.Review;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameApp.Application.Extensions;

public static class ApplicationDependencyInjection
{
      public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
      {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IReviewService, ReviewService>();

            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

            return services;
      }
}
