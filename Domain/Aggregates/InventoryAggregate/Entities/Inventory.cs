using Domain.Exceptions;

namespace Domain.InventoryAggregate.Entities;

/// <summary>
/// This is the root entity for the Inventory aggregate
/// </summary>
public class Inventory
{

    private readonly IList<Item> _items;

    /// <summary>
    /// Constructor for this entity
    /// </summary>
    /// <param name="items">The intial items list</param>
    public Inventory(IList<Item> items)
    {
        _items = items;
    }

    /// <summary>
    /// Add a new item to the inventory
    /// </summary>
    /// <param name="name">Item's name</param>
    /// <param name="expirationDate">Item's expiration date</param>
    /// <param name="type">Item's type</param>
    /// <returns>The newly created item</returns>
    /// <exception cref="AlreadyExistsException">If an item with the same name already exists</exception>
    public Item AddItem(string name, DateOnly expirationDate, ItemType type)
    {
        if (_items.Any(i => i.Name.Equals(name))) 
            throw new AlreadyExistsException();
        var item = new Item(name, expirationDate, type);
        _items.Add(item);
        return item;
    }

    /// <summary>
    /// Remove an item from the inventory
    /// </summary>
    /// <param name="name">Item's name</param>
    public void RemoveItem(string name)
    {
        var found = _items.Where(i => i.Name.Equals(name)).ToList();

        found.ForEach(item =>
        {
            _items.Remove(item);
        });
    }

    /// <summary>
    /// Get all items
    /// </summary>
    /// <returns>The complete items list</returns>
    public IList<Item> GetItems()
    {
        return _items;
    }

    /// <summary>
    /// Mark items as expired
    /// </summary>
    /// <param name="date">The date to compare to</param>
    /// <returns>The expired items list</returns>
    public IList<Item> MarkAsExpired(DateOnly date)
    {
        return _items.Where(item => item.MarkAsExpired(date)).ToList();
    }
}