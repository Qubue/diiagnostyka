using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class PersistenceRegistration
{
        public static void RegisterPersistence(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("database"));
        }
}