using Domain.InventoryAggregate;
using Domain.Services.Commands;

namespace Domain.Services.Factories;

public class RemoveItemCommandFactory
{

    private InventoryRepository _inventoryRepository;
    
    public RemoveItemCommand Create(string name)
    {
        return new RemoveItemCommand(_inventoryRepository, name);
    }
}