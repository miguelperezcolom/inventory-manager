using Domain.InventoryAggregate;
using Domain.Services.Events;

namespace Domain.Services.Commands;

public class RemoveItemCommand
{
    private InventoryRepository _inventoryRepository;
    private IEventBus _eventBus;

    private string _name;

    public RemoveItemCommand(InventoryRepository inventoryRepository, IEventBus eventBus, string name)
    {
        _inventoryRepository = inventoryRepository;
        _name = name;
        _eventBus = eventBus;
    }

    public async Task RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        inventory.RemoveItem(_name);
        _eventBus.Publish(new ItemRemoved(_name));
        _inventoryRepository.Save(inventory);
    }    
}