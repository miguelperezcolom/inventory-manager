using Domain.InventoryAggregate;

namespace Infrastructure;

public class InMemoryInventoryRepository : InventoryRepository
{

    private Inventory _inventory = new Inventory(new List<Item>());
    
    public Inventory Save(Inventory inventory)
    {
        _inventory = inventory;
        return _inventory;
    }

    public Inventory Load()
    {
        return _inventory;
    }
}