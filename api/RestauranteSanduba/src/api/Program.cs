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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RestauranteSanduba.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var jwtSecretKey = builder.Configuration.GetValue<string>("JwtSettings:SecretKey") ?? string.Empty;
            var jwtIssuer = builder.Configuration.GetValue<string>("JwtSettings:Issuer") ?? string.Empty;
            var jwtAudience = builder.Configuration.GetValue<string>("JwtSettings:Audience") ?? string.Empty;

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = jwtAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey)),
                });

            builder.Services.AddAuthorization();

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
                        },
                    });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Adicione o JWT",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
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

            app.UseAuthentication();
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