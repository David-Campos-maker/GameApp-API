using System;
using GameApp.Application.Helpers;
using GameApp.Application.Services.Game;
using GameApp.Application.Services.Identity;
using GameApp.Application.Services.Photo;
using GameApp.Application.Services.Review;
using GameApp.Application.Services.Token;
using GameApp.Application.Services.UserProfile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameApp.Application.Extensions;

public static class ApplicationDependencyInjection
{
      public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
      {
            // System services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();

            // Entity services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IUserProfileService, UserProfileService>();

            // Cofigure services settings
            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.Configure<JwtSettings>(configuration.GetSection("JWT"));

            return services;
      }
}
