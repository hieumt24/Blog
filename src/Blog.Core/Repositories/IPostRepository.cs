using Blog.Core.Domain.Content;
using Blog.Core.Models;
using Blog.Core.Models.Content;
using Blog.Core.SeedWorks;

namespace Blog.Core.Repositories;

public interface IPostRepository : IRepository<Post, Guid>
{
    Task<List<Post>> GetPopularPostsAsync(int count);
    Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
}
