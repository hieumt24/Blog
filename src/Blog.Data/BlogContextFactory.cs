using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blog.Data;

public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
{
    public BlogContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<BlogContext>();
        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        return new BlogContext(builder.Options);
    }
}