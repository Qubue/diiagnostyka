using Application.Item;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationDependencyInjection
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
    }
}