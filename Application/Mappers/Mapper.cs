using Application.Model;

namespace Application.Mappers;

public static class Mapper
{
    public static Item MapToModel(Domain.InventoryAggregate.Item item)
    {
        return new Item()
        {
            Name = item.Name,
            ExpirationDate = item.ExpirationDate,
            Type = item.Type
        };
    }
    
    public static IList<Item> MapToModel(IList<Domain.InventoryAggregate.Item> items)
    {
        return items.Select(item => MapToModel(item)).ToList();
    }
    public static Domain.InventoryAggregate.Item MapToDomain(Item item)
    {
        return new Domain.InventoryAggregate.Item(item.Name, item.ExpirationDate, item.Type);
    }

}