using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Infra.PersistenceGateway.Redis.PersistenceGateway.Redis.Carrinho;

namespace RestauranteSanduba.Infra.PersistenceGateway.Redis.PersistenceGateway.Redis
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddRedisInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("CarrinhoDatabase:Value") ?? string.Empty;

            services.AddScoped<ICarrinhoPersistenceGateway, CarrinhoRepository>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = connectionString;
            });


            return services;
        }
    }
}
