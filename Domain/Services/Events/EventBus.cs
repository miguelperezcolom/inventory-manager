namespace Domain.Services.Events;

public interface IEventBus
{
    void Publish(Event anEvent);
}