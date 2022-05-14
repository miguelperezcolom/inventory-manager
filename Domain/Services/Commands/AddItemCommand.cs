using Domain.InventoryAggregate;

namespace Domain.Services.Commands;

public class AddItemCommand
{
    private InventoryRepository _inventoryRepository;
    
    private string _name;

    private DateOnly _expirationDate;

    private ItemType _type;

    public AddItemCommand(InventoryRepository inventoryRepository, string name, DateOnly expirationDate, ItemType type)
    {
        _inventoryRepository = inventoryRepository;
        _name = name;
        _expirationDate = expirationDate;
        _type = type;
    }

    public async Task RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        inventory.AddItem(_name, _expirationDate, _type);
        _inventoryRepository.Save(inventory);
    }
}