using Domain.InventoryAggregate;

namespace Application.Model;

public class Item
{
    public string Name { get; set; }
    
    public DateOnly ExpirationDate { get; set; }

    public ItemType type { get; set; }

}