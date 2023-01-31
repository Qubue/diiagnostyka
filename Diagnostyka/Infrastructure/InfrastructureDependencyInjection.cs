using Application.Identity;
using Application.Item;
using Domain;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDependencyInjection
{
        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemItemRepository>();
            services.AddScoped<IUserCredentialManager, StubCredentialManager>();
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("database"));
        }
}