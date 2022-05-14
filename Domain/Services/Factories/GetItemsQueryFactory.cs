using Domain.InventoryAggregate;
using Domain.Services.Commands;
using Domain.Services.Queries;

namespace Domain.Services.Factories;

public class GetItemsQueryFactory
{

    private InventoryRepository _inventoryRepository;
    
    public GetItemsQuery Create(string name)
    {
        return new GetItemsQuery(_inventoryRepository);
    }
}