using System.Collections.Generic;
using System;

namespace RestauranteSanduba.API.Carrinhos.Requests
{
    public record AdicionarProdutoRequest(List<Guid> Itens);
}
