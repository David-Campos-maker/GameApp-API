using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace GameApp.API.Extensions;

public static class OpenApiExtensions
{
      public static IServiceCollection AddSwaggerScalarConfig(this IServiceCollection services)
      {
            services.AddOpenApi(options =>
            {
                  options.AddDocumentTransformer((document, context, cancellationToken) =>
                  {
                        var schemeName = "Bearer";

                        document.Components ??= new OpenApiComponents();
                        document.Components.SecuritySchemes.Add(schemeName, new OpenApiSecurityScheme
                        {
                              Type = SecuritySchemeType.Http,
                              Scheme = "bearer", 
                              In = ParameterLocation.Header,
                              BearerFormat = "Json Web Token"
                        });

                        document.SecurityRequirements.Add(new OpenApiSecurityRequirement
                        {
                              [new OpenApiSecurityScheme
                              {
                                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = schemeName }
                              }] = Array.Empty<string>()
                        });

                        return Task.CompletedTask;
                  });
            });

            return services;
      }
}
