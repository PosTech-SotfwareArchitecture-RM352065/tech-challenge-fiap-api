using System;

namespace RestauranteSanduba.Core.Domain.Common.Events
{
    public record DomainEvent
    {
        public DateTimeOffset OccurredAt { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
