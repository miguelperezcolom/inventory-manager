using Domain.InventoryAggregate.Entities;

namespace Domain.InventoryAggregate;

/// <summary>
/// Inventory's reporitory interface
/// </summary>
public interface IInventoryRepository
{
    /// <summary>
    /// Save an inventory
    /// </summary>
    /// <param name="inventory">The inventory to be saved</param>
    /// <returns>The saved inventory</returns>
    Inventory Save(Inventory inventory);
    
    /// <summary>
    /// Load the inventory
    /// </summary>
    /// <returns>The inventory</returns>
    Inventory Load();
}