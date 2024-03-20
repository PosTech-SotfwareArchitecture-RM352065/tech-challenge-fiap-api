using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.RequestModel;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel;
using RestauranteSanduba.Core.Application.Abstraction.Carrinhos;
using RestauranteSanduba.Core.Domain.Common.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteSanduba.Core.Application.Carrinhos
{
    public class CarrinhoInteractor : ICarrinhoInteractor
    {
        private readonly ICarrinhoPersistenceGateway CarrinhoPersistenteceGateway;

        public CarrinhoInteractor(ICarrinhoPersistenceGateway CarrinhoPersistenceGateway)
        {
            this.CarrinhoPersistenteceGateway = CarrinhoPersistenceGateway;
        }
        public CadastroCarrinhoResponse CadastrarProduto(CadastroCarrinhoRequest requestModel)
        {
            try
            {
                CarrinhoPersistenteceGateway.CadastrarProduto(requestModel.ClienteId, requestModel.ProdutoId);

                return new CadastroCarrinhoResponse(requestModel.ClienteId);
            }
            catch (DomainException ex)
            {
                throw ex;
            }
        }

        public List<ConsultaCarrinhoResponse> ConsultarProdutos(ConsultaCarrinhoRequest requestModel)
        {
            var produtos = CarrinhoPersistenteceGateway.ConsultarProdutos(requestModel.ClienteId);
            return produtos.Select(produto =>
                new ConsultaCarrinhoResponse
                (
                    Id: produto
                )).ToList();
        }

        public ConsultaCarrinhoResponse RemoverProduto(RemoveCarrinhoRequest requestModel)
        {
            CarrinhoPersistenteceGateway.RemoverProduto(requestModel.ClienteId, requestModel.ProdutoId);
            return new ConsultaCarrinhoResponse
            (
                Id: requestModel.ProdutoId
            );
        }
    }
}
