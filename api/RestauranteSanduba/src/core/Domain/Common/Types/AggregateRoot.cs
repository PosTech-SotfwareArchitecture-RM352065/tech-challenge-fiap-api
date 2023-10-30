using System;

namespace RestauranteSanduba.Core.Domain.Common.Types
{
    public abstract class AggregateRoot : Entity<Guid>
    {
        protected AggregateRoot(Guid id) : base(id) { }
    }
}
