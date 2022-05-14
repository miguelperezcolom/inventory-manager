using Domain.InventoryAggregate;
using Domain.Services.Commands;
using Domain.Services.Events;
using Domain.Services.Queries;

namespace Domain.Services.Factories;

public class CommandFactory
{

    private readonly InventoryRepository _inventoryRepository;
    private readonly IEventBus _eventBus;


    public CommandFactory(InventoryRepository inventoryRepository, IEventBus eventBus)
    {
        _inventoryRepository = inventoryRepository;
        _eventBus = eventBus;
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
        return new RemoveItemCommand(_inventoryRepository, _eventBus, name);
    }
    public MarkAsExpiredCommand CreateMarkAsExpiredCommand(DateOnly date)
    {
        return new MarkAsExpiredCommand(_inventoryRepository, _eventBus, date);
    }
}