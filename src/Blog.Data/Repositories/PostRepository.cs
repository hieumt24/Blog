using Blog.Core.Domain.Content;
using Blog.Core.Repositories;
using Blog.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Repositories;

public class PostRepository : RepositoryBase<Post, Guid>, IPostRepository
{
    public PostRepository(BlogContext context) : base(context)
    {
    }

    public  async Task<List<Post>> GetPopularPostsAsync(int count)
    {
        return await _context.Posts.OrderByDescending(x => x.ViewCount)
            .Take(count)
            .ToListAsync();
    }
}