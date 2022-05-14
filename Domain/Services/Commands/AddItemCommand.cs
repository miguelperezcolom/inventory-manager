using Domain.InventoryAggregate;
using Domain.InventoryAggregate.Entities;

namespace Domain.Services.Commands;

public class AddItemCommand
{
    private readonly IInventoryRepository _inventoryRepository;
    
    private readonly string _name;

    private readonly DateOnly _expirationDate;

    private readonly ItemType _type;

    public AddItemCommand(IInventoryRepository inventoryRepository, string name, DateOnly expirationDate, ItemType type)
    {
        _inventoryRepository = inventoryRepository;
        _name = name;
        _expirationDate = expirationDate;
        _type = type;
    }

    public async Task<Item> RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        var item = inventory.AddItem(_name, _expirationDate, _type);
        _inventoryRepository.Save(inventory);
        return item;
    }
}