namespace Blog.Core.SeedWorks;

public interface IUnitOfWork
{
    Task<int> CompleteAsync();
}