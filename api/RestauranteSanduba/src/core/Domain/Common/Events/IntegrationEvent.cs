using MediatR;
using System;

namespace RestauranteSanduba.Core.Domain.Common.Events
{
    public record IntegrationEvent : INotification
    {
        public DateTimeOffset OccurredAt { get; protected set; } = DateTime.UtcNow;
        public string EventType { get; protected set; }
    }
}
