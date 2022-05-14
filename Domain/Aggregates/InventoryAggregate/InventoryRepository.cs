namespace Domain.InventoryAggregate;

/// <summary>
/// My method does stuff.
/// </summary>
public interface InventoryRepository
{
    Inventory Save(Inventory inventory);
    
    Inventory Load();
}