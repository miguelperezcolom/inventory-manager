using Domain.InventoryAggregate;

namespace Domain.Services.Commands;

public class RemoveItemCommand
{
    private InventoryRepository _inventoryRepository;
    
    private string _name;

    public RemoveItemCommand(InventoryRepository inventoryRepository, string name)
    {
        _inventoryRepository = inventoryRepository;
        _name = name;
    }

    public async Task RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        inventory.RemoveItem(_name);
        _inventoryRepository.Save(inventory);
    }    
}