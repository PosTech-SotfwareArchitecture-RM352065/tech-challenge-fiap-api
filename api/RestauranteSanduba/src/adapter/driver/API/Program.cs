using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Pedidos;
using RestauranteSanduba.Core.Application.Pedidos;
using RestauranteSanduba.Core.Domain.Pedidos.Interfaces;
using System;

namespace RestauranteSanduba.Adapter.Driven.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHealthChecks();
            //    .AddSqlServer(
            //        builder.Configuration.GetConnectionString("DefaultConnection"));

            builder.Services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(15);
                options.MaximumHistoryEntriesPerEndpoint(60);
                options.SetApiMaxActiveRequests(1);

                options.AddHealthCheckEndpoint("Restaurante Sanduba API", "/health");
            }).AddInMemoryStorage();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Documentação Swagger da APU Restaurante Sanduba",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Victor Cangelosi de Lima - RM352065",
                            Email = "mktcangel@gmail.com"
                        }
                    });

                options.EnableAnnotations();
            });

            builder.Services.AddTransient<IPedidoService, PedidoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseReDoc(doc =>
                {
                    doc.DocumentTitle = "Documentação da API Restaurante Sanduba";
                    doc.SpecUrl = "/swagger/v1/swagger.json";

                });
            }

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).UseHealthChecksUI(options => options.UIPath = "/health-ui");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}