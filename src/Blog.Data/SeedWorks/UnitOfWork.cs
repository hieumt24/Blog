using Blog.Core.SeedWorks;

namespace Blog.Data.SeedWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogContext _context;

    public UnitOfWork(BlogContext context)
    {
        _context = context;
    }
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}