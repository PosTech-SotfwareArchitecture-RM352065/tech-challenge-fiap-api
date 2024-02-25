using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RestauranteSanduba.Core.Application;
using System;
using RestauranteSanduba.Adapter.ApiAdapter;
using RestauranteSanduba.Infra.PersistenceGateway.SqlServer;

namespace RestauranteSanduba.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            builder.Services.AddHealthChecks()
                .AddDatabaseHealthChecks(builder.Configuration);

            builder.Services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(15);
                options.MaximumHistoryEntriesPerEndpoint(60);
                options.SetApiMaxActiveRequests(1);

            }).AddInMemoryStorage();

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddApiAdapter(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = $"Documentação Swagger da API Restaurante Sanduba - {environment}",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Victor Cangelosi de Lima - RM352065",
                            Email = "mktcangel@gmail.com"
                        }
                    });

                options.EnableAnnotations();
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseReDoc(doc =>
            {
                doc.DocumentTitle = "Documentação da API Restaurante Sanduba";
                doc.SpecUrl = "/swagger/v1/swagger.json";

            });

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true
            })
            .UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .UseHealthChecksUI(options => options.UIPath = "/healthz-ui");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static IHealthChecksBuilder AddDatabaseHealthChecks(this IHealthChecksBuilder services, IConfiguration configuration)
        {
            foreach (var databaseConfig in configuration.GetSection("ConnectionStrings").GetChildren())
            {
                switch (databaseConfig.GetValue<string>("Type"))
                {
                    case "MSSQL":
                        services.AddSqlServer(connectionString: databaseConfig.GetValue<string>("Value"), name: databaseConfig.Key);
                        break;
                    case "REDIS":
                        services.AddRedis(redisConnectionString: databaseConfig.GetValue<string>("Value"), name: databaseConfig.Key);
                        break;
                }
            }

            return services;
        }
    }
}