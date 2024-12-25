using System.Linq.Expressions;
using Blog.Core.SeedWorks;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.SeedWorks;

public class RepositoryBase<T, Key>: IRepository<T, Key> where T : class
{
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(BlogContext context)
    {
        _dbSet = context.Set<T>();
    }
    public async Task<T> GetByIdAsync(Key id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }

    public void Add(T entity)
    {
        _dbSet.AddAsync(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}