namespace Domain.InventoryAggregate;

public class Item
{
    
    public string Name { get; }

    public DateOnly ExpirationDate { get; }
    
    public ItemType Type { get; }

    public Item(string name, DateOnly expirationDate, ItemType type)
    {
        Name = name;
        ExpirationDate = expirationDate;
        Type = type;
    }

}