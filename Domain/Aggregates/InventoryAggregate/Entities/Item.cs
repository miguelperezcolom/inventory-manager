namespace Domain.InventoryAggregate;

public class Item
{
    
    public string Name { get; }

    public DateOnly ExpirationDate { get; }
    
    public ItemType Type { get; }

    public bool Expired { get; set; }

    public Item(string name, DateOnly expirationDate, ItemType type)
    {
        Name = name;
        ExpirationDate = expirationDate;
        Type = type;
    }

    public bool MarkAsExpired(DateOnly date)
    {
        if (Expired) return false;
        if (ExpirationDate < date)
        {
            Expired = true;
        };
        return Expired;
    }
}