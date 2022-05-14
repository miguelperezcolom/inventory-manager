using Domain.Services.Events;

namespace Infrastructure;

public class SimpleEventBus : IEventBus
{
    public void Publish(Event anEvent)
    {
        Console.WriteLine($"Event {anEvent} published");
    }
}