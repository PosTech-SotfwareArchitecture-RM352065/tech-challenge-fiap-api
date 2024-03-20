using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;
using RestauranteSanduba.Core.Application.Cardapios;
using RestauranteSanduba.Core.Application.Carrinhos;
using RestauranteSanduba.Core.Application.Clientes;
using RestauranteSanduba.Core.Application.Pedidos;

namespace RestauranteSanduba.Core.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPedidoInteractor, PedidoInteractor>();
            services.AddTransient<IClienteInteractor, ClienteInteractor>();
            services.AddTransient<ICardapioInteractor, CardapioInteractor>();
            services.AddTransient<ICarrinhoInteractor, CarrinhoInteractor>();

            return services;
        }
    }
}
