using Domain.InventoryAggregate;
using Domain.InventoryAggregate.Entities;

namespace Domain.Services.Queries;

public class GetItemsQuery
{
    private readonly IInventoryRepository _inventoryRepository;
    
    public GetItemsQuery(IInventoryRepository inventoryRepository)
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