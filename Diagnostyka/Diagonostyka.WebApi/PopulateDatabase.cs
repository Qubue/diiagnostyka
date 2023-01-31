using Domain.Core;
using Domain.Core.Entities;

namespace Diagonostyka.WebApi;

public static class PopulateDatabase
{
    public static void Populate(WebApplication app)
    {
        var scopeFactory = app.Services.GetService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationContext>();

            context.Database.EnsureCreated();
            context.Colors.Add(new ColorEntity
                { Color = "Red", Id = 1 });
            context.Colors.Add(new ColorEntity
                { Color = "Blue", Id = 2 });

            context.Items.Add(new ItemEntity
            {
                Code = "code1",
                ColorId = 1,
                Name = "name1",
                Notes = "notes1",
                Id = 1
            });

            context.Items.Add(new ItemEntity
            {
                Code = "code2",
                ColorId = 1,
                Name = "name2",
                Notes = "notes2",
                Id = 2
            });
            context.Items.Add(new ItemEntity
            {
                Code = "code3",
                ColorId = 1,
                Name = "name3",
                Notes = "notes3",
                Id = 3
            });

            context.SaveChanges();
        }
    }
}
    