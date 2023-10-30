using MediatR;
using System;

namespace RestauranteSanduba.Core.Domain.Common.Events
{
    public record DomainEvent : INotification
    {
        public DateTimeOffset OccurredAt { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
