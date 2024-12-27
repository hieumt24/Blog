using Blog.Core.Repositories;

namespace Blog.Core.SeedWorks;

public interface IUnitOfWork
{
    IPostRepository Posts { get; }
    Task<int> CompleteAsync();
}