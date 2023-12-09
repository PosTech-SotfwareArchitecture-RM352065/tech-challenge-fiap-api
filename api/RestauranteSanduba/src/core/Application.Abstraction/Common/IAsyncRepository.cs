using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Common
{
    internal interface IAsyncRepository<T> where T : class
    {
        Task<Guid> Adicionar(T entidade, CancellationToken cancellationToken = default);
        Task<IEnumerable<Guid>> Adicionar(IEnumerable<T> entidades, CancellationToken cancellationToken = default);
        Task Atualizar(T entidade, CancellationToken cancellationToken = default);
        Task Atualizar(IEnumerable<T> entidades, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> Listar(CancellationToken cancellationToken = default);
        Task<T> Remover (Guid id, CancellationToken cancellationToken = default);
        Task<T> Remover(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<T> ObterPorId (Guid id, CancellationToken cancellationToken = default);

    }
}
