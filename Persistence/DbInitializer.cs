using System;
using Domain;

namespace Persistence;

public class DbInitializer
{
    public static async Task SeedData(AppDbContext context)
    {
        //example of how to seed data
        if (context.ExampleEntities.Any()) return;

        var exampleEntities = new List<ExampleEntity>
        {
            new()
            {
                Title = "Example"
            }
        };

        context.ExampleEntities.AddRange(exampleEntities);

        await context.SaveChangesAsync();
    }
}
