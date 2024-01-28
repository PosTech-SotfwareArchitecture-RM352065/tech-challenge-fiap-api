using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSanduba.Adapter.Driven.Persistence.Cardapios;
using RestauranteSanduba.Adapter.Driven.Persistence.Clientes;
using RestauranteSanduba.Adapter.Driven.Persistence.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;

namespace RestauranteSanduba.Adapter.Driven.Persistence
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
            });

            services.AddTransient<IClientePersistenceGateway, ClienteRepository>();
            services.AddTransient<IPedidoPersistenceGateway, PedidoRepository>();
            services.AddTransient<ICardapioPersistenceGateway, CardapioRepository>();

            return services;
        }
    }
}
