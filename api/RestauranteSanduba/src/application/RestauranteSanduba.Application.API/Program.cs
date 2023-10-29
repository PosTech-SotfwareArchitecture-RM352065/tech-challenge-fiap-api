using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace RestauranteSanduba.Application.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}