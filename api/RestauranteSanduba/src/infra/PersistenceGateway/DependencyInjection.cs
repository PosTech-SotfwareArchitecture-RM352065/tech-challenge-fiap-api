using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Infra.PersistenceGateway.Cardapios;
using RestauranteSanduba.Infra.PersistenceGateway.Clientes;
using RestauranteSanduba.Infra.PersistenceGateway.Pedidos;

namespace RestauranteSanduba.Infra.PersistenceGateway
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<InfrastructureDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IClientePersistenceGateway, ClienteRepository>();
            services.AddScoped<IPedidoPersistenceGateway, PedidoRepository>();
            services.AddScoped<ICardapioPersistenceGateway, CardapioRepository>();

            return services;
        }
    }
}
