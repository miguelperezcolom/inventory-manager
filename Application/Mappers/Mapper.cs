using Application.Model;

namespace Application.Mappers;

public static class Mapper
{
    public static Item MapToModel(Domain.InventoryAggregate.Entities.Item item)
    {
        return new Item()
        {
            Name = item.Name,
            ExpirationDate = item.ExpirationDate,
            Type = item.Type
        };
    }
    
    public static IList<Item> MapToModel(IList<Domain.InventoryAggregate.Entities.Item> items)
    {
        return items.Select(item => MapToModel(item)).ToList();
    }

}