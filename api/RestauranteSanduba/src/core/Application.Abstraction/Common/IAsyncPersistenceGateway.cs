using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestauranteSanduba.Core.Application.Abstraction.Common
{
    internal interface IAsyncPersistenceGateway<T> where T : class
    {
        Task<Guid> Adicionar(T entidade, CancellationToken cancellationToken = default);
        Task<IEnumerable<Guid>> Adicionar(IEnumerable<T> entidades, CancellationToken cancellationToken = default);
        Task Atualizar(T entidade, CancellationToken cancellationToken = default);
        Task Atualizar(IEnumerable<T> entidades, CancellationToken cancellationToken = default);
        Task<T> Remover(Guid id, CancellationToken cancellationToken = default);
        Task<T> Remover(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<T> Buscar(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> Buscar(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> Buscar(CancellationToken cancellationToken = default);

    }
}
