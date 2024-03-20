using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using System;

namespace RestauranteSanduba.Infra.PersistenceGateway.Redis.PersistenceGateway.Redis.Carrinho
{
    public class CarrinhoRepository : ICarrinhoPersistenceGateway
    {
        private readonly IDistributedCache _dbContext;
        private readonly DistributedCacheEntryOptions _options;

        public CarrinhoRepository(IDistributedCache dbContext)
        {
            _dbContext = dbContext;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(10),
            };
        }

        public void CadastrarProduto(Guid cliente, Guid produto)
        {
            List<Guid> list = new();

            var bytes = _dbContext.Get(cliente.ToString());
            if (bytes is not null && bytes.Length > 0)
            {
                var strContent = Encoding.UTF8.GetString(bytes);
                list = JsonSerializer.Deserialize<List<Guid>>(strContent);
            }
            list.Add(produto);

            var json = JsonSerializer.Serialize(list);
            _dbContext.Set(cliente.ToString(), Encoding.UTF8.GetBytes(json));
        }

        public List<Guid> ConsultarProdutos(Guid cliente)
        {
            List<Guid> list = new();

            var bytes = _dbContext.Get(cliente.ToString());
            if (bytes is null || bytes?.Length <= 0) return list;

            var strContent = Encoding.UTF8.GetString(bytes);
            if (string.IsNullOrEmpty(strContent)) return list;

            list = JsonSerializer.Deserialize<List<Guid>>(strContent);

            return list;
        }

        public void RemoverProduto(Guid cliente, Guid produto)
        {
            var bytes = _dbContext.Get(cliente.ToString());
            if (bytes is null || bytes.Length <= 0) return;

            var strContent = Encoding.UTF8.GetString(bytes);
            var list = JsonSerializer.Deserialize<List<Guid>>(strContent);

            list.Remove(produto);

            var json = JsonSerializer.Serialize(list);
            _dbContext.Set(cliente.ToString(), Encoding.UTF8.GetBytes(json));
        }
    }
}
