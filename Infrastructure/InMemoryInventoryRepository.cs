using Domain.InventoryAggregate;
using Domain.InventoryAggregate.Entities;

namespace Infrastructure;

/// <summary>
/// In memory implementation of the inventory repository
/// </summary>
public class InMemoryInventoryRepository : IInventoryRepository
{

    private Inventory _inventory = new Inventory(new List<Item>());
    
    /// <summary>
    /// Save the inventory
    /// </summary>
    /// <param name="inventory">The inventory to be saved</param>
    /// <returns>The saved inventory</returns>
    public Inventory Save(Inventory inventory)
    {
        _inventory = inventory;
        return _inventory;
    }

    /// <summary>
    /// Load the inventory
    /// </summary>
    /// <returns>The inventory</returns>
    public Inventory Load()
    {
        return _inventory;
    }
}