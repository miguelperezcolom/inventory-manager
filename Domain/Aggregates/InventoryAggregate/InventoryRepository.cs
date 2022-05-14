namespace Domain.InventoryAggregate;

public interface InventoryRepository
{
    Inventory Save(Inventory inventory);
    
    Inventory Load();
}