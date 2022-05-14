namespace Domain.Services.Events;

public class ItemExpired : Event
{
    public ItemExpired(string itemName)
    {
        ItemName = itemName;
    }

    public string ItemName { get; }
    
    
}