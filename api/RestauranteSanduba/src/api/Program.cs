using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RestauranteSanduba.Infra.PersistenceGateway;
using RestauranteSanduba.Core.Application;
using System;
using RestauranteSanduba.Adapter.ApiAdapter;

namespace RestauranteSanduba.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Default' not found.");

            builder.Services.AddHealthChecks()
                .AddSqlServer(connectionString, name: "database");

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
    }
}