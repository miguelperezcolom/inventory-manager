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
        services.AddScoped<IEventBus, SimpleEventBus>();
        services.AddScoped<IInventoryRepository, InMemoryInventoryRepository>();
        services.AddScoped<CommandFactory, CommandFactory>();

        return services;
    }
}