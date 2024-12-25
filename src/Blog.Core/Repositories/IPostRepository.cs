using Blog.Core.Domain.Content;
using Blog.Core.SeedWorks;

namespace Blog.Core.Repositories;

public interface IPostRepository : IRepository<Post, Guid>
{
    Task<List<Post>> GetPopularPostsAsync(int count);
}