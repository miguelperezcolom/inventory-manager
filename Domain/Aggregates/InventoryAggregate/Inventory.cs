namespace Domain.InventoryAggregate;

public class Inventory
{

    private IList<Item> _items;

    public Inventory(IList<Item> items)
    {
        _items = items;
    }

    public void AddItem(string name, DateOnly expirationDate, ItemType type)
    {
        if (_items.Where(i => i.Name.Equals(name)).Any()) 
            throw new Exception("Already exists");
        
        _items.Add(new Item(name, expirationDate, type));
    }

    public void RemoveItem(string name)
    {
        var found = _items.Where(i => i.Name.Equals(name)).ToList();

        found.ForEach(item =>
        {
            _items.Remove(item);
        });
    }

    public IList<Item> GetItems()
    {
        return _items;
    }

}