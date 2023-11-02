using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Cardapios;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Clientes;
using RestauranteSanduba.Adapter.Driven.Infrastructure.Pedidos;
using RestauranteSanduba.Core.Application.Cardapios.Abstractions;
using RestauranteSanduba.Core.Application.Clientes.Abstractions;
using RestauranteSanduba.Core.Application.Pedidos.Abstractions;

namespace RestauranteSanduba.Adapter.Driven.Infrastructure
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

            services.AddDbContext<InfrastructureDbContext>(options => {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<ICardapioRepository, CardapioRepository>();

            return services;
        }
    }
}
