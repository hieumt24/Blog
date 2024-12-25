using Blog.Data;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api;

public static class MigrationManager
{
    public static WebApplication MigrationDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using (var context = scope.ServiceProvider.GetRequiredService<BlogContext>())
            {
                context.Database.Migrate();
                new DataSeeder().SeedAsync(context).Wait();
            }
        }

        return app;
    }
}