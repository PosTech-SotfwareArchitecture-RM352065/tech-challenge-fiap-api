using System;
using System.Collections.Generic;

namespace RestauranteSanduba.Core.Application.Abstraction.Carrinhos.ResponseModel
{
    public record RemoveCarrinhoResponseModel(List<Guid> Produtos);
}
