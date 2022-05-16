using Domain.InventoryAggregate;
using Domain.Services.Events;

namespace Domain.Services.Commands;

public class MarkAsExpiredCommand
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IEventBus _eventBus;
    
    private readonly DateOnly _date;

    public MarkAsExpiredCommand(IInventoryRepository inventoryRepository, IEventBus eventBus, DateOnly date)
    {
        _inventoryRepository = inventoryRepository;
        _eventBus = eventBus;
        _date = date;
    }

    public async Task RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        var expiredItems = inventory.MarkAsExpired(_date);
        //todo: separate in query and command
        foreach (var expiredItem in expiredItems)
        {
            _eventBus.Publish(new ItemExpired(expiredItem.Name));            
        }
        _inventoryRepository.Save(inventory);
    }
}