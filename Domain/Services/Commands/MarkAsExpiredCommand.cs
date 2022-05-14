using Domain.InventoryAggregate;
using Domain.Services.Events;

namespace Domain.Services.Commands;

public class MarkAsExpiredCommand
{
    private InventoryRepository _inventoryRepository;
    private IEventBus _eventBus;
    
    private DateOnly _date;

    public MarkAsExpiredCommand(InventoryRepository inventoryRepository, IEventBus eventBus, DateOnly date)
    {
        _inventoryRepository = inventoryRepository;
        _eventBus = eventBus;
        _date = date;
    }

    public async Task RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        var expiredItems = inventory.MarkAsExpired(_date);
        //todo: separar en query y command
        foreach (var expiredItem in expiredItems)
        {
            _eventBus.Publish(new ItemExpired(expiredItem.Name));            
        }
        _inventoryRepository.Save(inventory);
    }
}