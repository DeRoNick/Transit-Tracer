using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TransitTracer.Application.Infrastructure.Exceptions;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;
using TransitTracer.Persistence.Database;

namespace TransitTracer.Persistence.Repositories;

public class RoutesRepository : IRoutesRepository
{
    private readonly DbSet<Route> _routes;

    public RoutesRepository(TransitTrackerDbContext context)
    {
        _routes = context.Routes;
    }
    
    public async Task InsertAsync(Route data, CancellationToken token)
    {
        await _routes.AddAsync(data, token).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Route>> GetManyAsync(Expression<Func<Route, bool>> expression, CancellationToken token)
    {
        return await _routes.Where(expression).ToListAsync(token).ConfigureAwait(false);
    }

    public async Task<Route> GetAsync(Expression<Func<Route, bool>> expression, CancellationToken token)
    {
        return await _routes.FirstOrDefaultAsync(expression, token).ConfigureAwait(false) ??
               throw new ObjectNotFoundException("Route for given expression not found");
    }

    public async Task<IEnumerable<Route>> GetAll(CancellationToken token)
    {
        return await _routes.ToListAsync(token).ConfigureAwait(false);
    }
}