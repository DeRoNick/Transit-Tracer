using System.Linq.Expressions;

namespace TransitTracer.Application.Infrastructure.Repositories;

public interface IRepository<T> where T : class
{
    public Task InsertAsync(T data, CancellationToken token);
    public Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> expression, CancellationToken token);
    public Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken token);
    public Task<IEnumerable<T>> GetAll(CancellationToken token);
}