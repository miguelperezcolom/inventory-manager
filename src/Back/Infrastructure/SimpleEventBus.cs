using Domain.Services.Events;

namespace Infrastructure;

/// <summary>
/// Simple implementation of the event bus
/// </summary>
public class SimpleEventBus : IEventBus
{
    /// <summary>
    /// Publish an event
    /// </summary>
    /// <param name="anEvent">The event to be published</param>
    public void Publish(Event anEvent)
    {
        Console.WriteLine($"Event {anEvent} published");
    }
}