namespace Domain.InventoryAggregate.Entities;

/// <summary>
/// Item's entity class
/// </summary>
public class Item
{
    
    /// <summary>
    /// Item's name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Item's expiration date
    /// </summary>
    public DateOnly ExpirationDate { get; }
    
    /// <summary>
    /// Item's type
    /// </summary>
    public ItemType Type { get; }

    public bool Expired { get; set; }

    protected internal Item(string name, DateOnly expirationDate, ItemType type)
    {
        Name = name;
        ExpirationDate = expirationDate;
        Type = type;
    }

    protected internal bool MarkAsExpired(DateOnly date)
    {
        if (Expired) return false;
        if (ExpirationDate < date)
        {
            Expired = true;
        }
        return Expired;
    }
}