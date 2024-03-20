using RestauranteSanduba.Core.Domain.Cardapios;
using RestauranteSanduba.Core.Domain.Clientes.Abstractions;
using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos
{
    public interface ICarrinhoPersistenceGateway
    {
        public void CadastrarProduto(Guid cliente, Guid produto);
        public void RemoverProduto(Guid cliente, Guid produto);
        public List<Guid> ConsultarProdutos(Guid clienteId);
    }
}
