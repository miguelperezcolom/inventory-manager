using Application.Model;

namespace Application.Mappers;

public static class Mapper
{
    public static Item MapToModel(Domain.InventoryAggregate.Entities.Item item)
    {
        return new Item()
        {
            Name = item.Name,
            ExpirationDate = item.ExpirationDate.ToString("yyyy-MM-dd"),
            Type = item.Type.ToString()
        };
    }
    
    public static IList<Item> MapToModel(IList<Domain.InventoryAggregate.Entities.Item> items)
    {
        return items.Select(item => MapToModel(item)).ToList();
    }

}