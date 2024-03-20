using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestauranteSanduba.Adapter.ApiAdapter.Cardapios;
using RestauranteSanduba.Adapter.ApiAdapter.Carrinhos;
using RestauranteSanduba.Adapter.ApiAdapter.Clientes;
using RestauranteSanduba.Adapter.ApiAdapter.Pedidos;
using RestauranteSanduba.Core.Application.Abstraction.Cardapios;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Core.Application.Abstraction.Clientes;
using RestauranteSanduba.Core.Application.Abstraction.Pedidos;

namespace RestauranteSanduba.Adapter.ApiAdapter
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddApiAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<CardapioController<string>, CardapioApiController>();
            services.AddTransient<CardapioPresenter<string>, CardapioApiPresenter>();
            services.AddTransient<ClienteController<string>, ClienteApiController>();
            services.AddTransient<ClientePresenter<string>, ClienteApiPresenter>();
            services.AddTransient<PedidoController<string>, PedidoApiController>();
            services.AddTransient<PedidoPresenter<string>, PedidoApiPresenter>();
            services.AddTransient<CarrinhoController<string>, CarrinhoApiController>();
            services.AddTransient<CarrinhoPresenter<string>, CarrinhoApiPresenter>();

            return services;
        }
    }
}
