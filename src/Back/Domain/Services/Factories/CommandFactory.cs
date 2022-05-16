using Domain.InventoryAggregate;
using Domain.Services.Commands;
using Domain.Services.Events;
using Domain.Services.Queries;

namespace Domain.Services.Factories;

/// <summary>
/// Factory for commands and queries
/// </summary>
public class CommandFactory
{

    private readonly IInventoryRepository _inventoryRepository;
    private readonly IEventBus _eventBus;


    /// <summary>
    /// Constructor for the command factory
    /// </summary>
    /// <param name="inventoryRepository">The inventory repository</param>
    /// <param name="eventBus">The event bus</param>
    public CommandFactory(IInventoryRepository inventoryRepository, IEventBus eventBus)
    {
        _inventoryRepository = inventoryRepository;
        _eventBus = eventBus;
    }

    /// <summary>
    /// Create an add item command
    /// </summary>
    /// <param name="name">The name of the new item</param>
    /// <param name="expirationDate">The expiration date for the new item</param>
    /// <param name="type">The type of the new item</param>
    /// <returns>The command</returns>
    public AddItemCommand CreateAddItemCommand(string name, DateOnly expirationDate, ItemType type)
    {
        return new AddItemCommand(_inventoryRepository, name, expirationDate, type);
    }
    
    /// <summary>
    /// Create a get items query
    /// </summary>
    /// <returns>The query</returns>
    public GetItemsQuery CreateGetItemsQuery()
    {
        return new GetItemsQuery(_inventoryRepository);
    }
    
    /// <summary>
    /// create a get item query
    /// </summary>
    /// <param name="name">The name of the item</param>
    /// <returns>The query</returns>
    public GetItemQuery CreateGetItemQuery(string name)
    {
        return new GetItemQuery(_inventoryRepository, name);
    }
    
    /// <summary>
    /// Create a remove item command
    /// </summary>
    /// <param name="name">The name of the item</param>
    /// <returns>The command</returns>
    public RemoveItemCommand CreateRemoveItemCommand(string name)
    {
        return new RemoveItemCommand(_inventoryRepository, _eventBus, name);
    }
    
    /// <summary>
    /// Create a mark as expired command
    /// </summary>
    /// <param name="date">The date to compare with</param>
    /// <returns>The command</returns>
    public MarkAsExpiredCommand CreateMarkAsExpiredCommand(DateOnly date)
    {
        return new MarkAsExpiredCommand(_inventoryRepository, _eventBus, date);
    }
}