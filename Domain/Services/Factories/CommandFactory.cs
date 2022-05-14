using Domain.InventoryAggregate;
using Domain.Services.Commands;
using Domain.Services.Queries;

namespace Domain.Services.Factories;

public class CommandFactory
{

    private readonly InventoryRepository _inventoryRepository;

    public CommandFactory(InventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public AddItemCommand CreateAddItemCommand(string name, DateOnly expirationDate, ItemType type)
    {
        return new AddItemCommand(_inventoryRepository, name, expirationDate, type);
    }
    
    public GetItemsQuery CreateGetItemsQuery()
    {
        return new GetItemsQuery(_inventoryRepository);
    }
    
    public GetItemQuery CreateGetItemQuery(string name)
    {
        return new GetItemQuery(_inventoryRepository, name);
    }
    
    public RemoveItemCommand CreateRemoveItemCommand(string name)
    {
        return new RemoveItemCommand(_inventoryRepository, name);
    }
}