using AutoMapper;
using Blog.Core.Repositories;
using Blog.Core.SeedWorks;
using Blog.Data.Repositories;

namespace Blog.Data.SeedWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogContext _context;

    public UnitOfWork(BlogContext context , IMapper mapper)
    {
        _context = context;
        Posts = new PostRepository(_context, mapper);
    }
    
    public IPostRepository Posts { get; private set; }
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}