using Domain.InventoryAggregate;

namespace Domain.Services.Queries;

public class GetItemQuery
{
    private InventoryRepository _inventoryRepository;
    private readonly string _name;

    public GetItemQuery(InventoryRepository inventoryRepository, string name)
    {
        _inventoryRepository = inventoryRepository;
        _name = name;
    }

    public async Task<Item> RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        var items = inventory.GetItems();
        return items.FirstOrDefault(item => item.Name.Equals(_name), null);
    }
}