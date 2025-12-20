using System;
using GameApp.Domain.Interfaces.Repositories;
using GameApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GameApp.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using GameApp.Infrastructure.Repositories;

namespace GameApp.Infrastructure.Extensions;

public static class InfrastructureDependencyInjection
{
      public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
      {
            services.AddDbContext<GameAppDbContext>(options => {
                  options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Identity setup
            services.AddIdentity<UserEntity, IdentityRole<int>>()
                  .AddEntityFrameworkStores<GameAppDbContext>();

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
      }
}
