using Rafiq.Domain.Common;

namespace Rafiq.Domain.Test.Events;

public sealed class TestCompleted : DomainEvent
{
    public Guid TestId { get; init; }
}