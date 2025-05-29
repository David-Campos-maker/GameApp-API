using System;
using GameApp.Infrastructure.Extensions;

namespace GameApp.API.Extensions;

public static class DependencyInjection
{
      public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
      {
            services.AddInfrastructureServices(config);
      }
}
