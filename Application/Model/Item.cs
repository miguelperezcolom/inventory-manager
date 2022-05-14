using Domain.InventoryAggregate;

namespace Application.Model;

public class Item
{
    public string Name { get; set; }
    
    public DateOnly ExpirationDate { get; set; }

    public ItemType Type { get; set; }

}