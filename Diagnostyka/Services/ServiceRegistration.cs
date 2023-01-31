using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class ServiceRegistration
{
    public static void RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
    }
}