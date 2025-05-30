using System;
using GameApp.Domain.Interfaces.Repositories;
using GameApp.Infrastructure.Repositories.Game;
using GameApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameApp.Infrastructure.Extensions;

public static class InfrastructureDependencyInjection
{
      public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
      {
            services.AddDbContext<GameAppDbContext>(options => {
                  options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IGameRepository, GameRepository>();

            return services;
      }
}
