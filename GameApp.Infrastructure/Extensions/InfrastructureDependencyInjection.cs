using System;
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

            return services;
      }
}
