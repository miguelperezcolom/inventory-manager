using Domain.InventoryAggregate;
using Domain.Services.Events;

namespace Domain.Services.Commands;

public class RemoveItemCommand
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IEventBus _eventBus;

    private readonly string _name;

    public RemoveItemCommand(IInventoryRepository inventoryRepository, IEventBus eventBus, string name)
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