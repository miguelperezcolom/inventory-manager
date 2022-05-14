using Domain.InventoryAggregate;
using Domain.Services.Commands;

namespace Domain.Services.Factories;

public class AddItemCommandFactory
{

    private InventoryRepository _inventoryRepository;
    
    public AddItemCommand Create(string name, DateOnly expirationDate, ItemType type)
    {
        return new AddItemCommand(_inventoryRepository, name, expirationDate, type);
    }
}