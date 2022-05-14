namespace Domain.Services.Events;

public class ItemRemoved : Event
{
    public ItemRemoved(string itemName)
    {
        ItemName = itemName;
    }

    public string ItemName { get; }
    
    
}