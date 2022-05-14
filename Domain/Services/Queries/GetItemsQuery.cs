using Domain.InventoryAggregate;

namespace Domain.Services.Queries;

public class GetItemsQuery
{
    private InventoryRepository _inventoryRepository;
    
    public GetItemsQuery(InventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<IList<Item>> RunAsync()
    {
        var inventory = _inventoryRepository.Load();
        var items = inventory.GetItems();
        return items;
    }
}