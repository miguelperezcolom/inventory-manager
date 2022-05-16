using Domain.InventoryAggregate;
using Domain.Services.Commands;
using Domain.Services.Events;
using Domain.Services.Factories;
using Infrastructure;

namespace Application.DI;

public static class DIExtension
{
    public static IServiceCollection AddDI(this IServiceCollection services)
    {
        services.AddSingleton<IEventBus, SimpleEventBus>();
        services.AddSingleton<IInventoryRepository, InMemoryInventoryRepository>();
        services.AddSingleton<CommandFactory, CommandFactory>();
        
        return services;
    }
}