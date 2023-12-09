using System;

namespace RestauranteSanduba.Core.Domain.Common.Events
{
    public record IntegrationEvent 
    {
        public DateTimeOffset OccurredAt { get; protected set; } = DateTime.UtcNow;
        public string EventType { get; protected set; }
    }
}
