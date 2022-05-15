using Domain.InventoryAggregate;

namespace Application.Model;

public class Item
{
    public string Name { get; set; }
    
    public string ExpirationDate { get; set; }

    public ItemType Type { get; set; }

}