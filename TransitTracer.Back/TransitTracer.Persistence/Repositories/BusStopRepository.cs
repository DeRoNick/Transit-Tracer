using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TransitTracer.Application.Infrastructure.Exceptions;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;
using TransitTracer.Persistence.Database;

namespace TransitTracer.Persistence.Repositories;

public class BusStopRepository : IBusStopRepository
{
    private readonly DbSet<BusStop> _busStops;

    public BusStopRepository(TransitTrackerDbContext context)
    {
        _busStops = context.BusStops;
    }
    
    public async Task InsertAsync(BusStop data, CancellationToken token)
    {
        await _busStops.AddAsync(data, token).ConfigureAwait(false);
    }

    public async Task<IEnumerable<BusStop>> GetManyAsync(Expression<Func<BusStop, bool>> expression, CancellationToken token)
    {
        return await _busStops.Where(expression).ToListAsync(token).ConfigureAwait(false);
    }

    public async Task<BusStop> GetAsync(Expression<Func<BusStop, bool>> expression, CancellationToken token)
    {
        return await _busStops.SingleOrDefaultAsync(expression, token).ConfigureAwait(false) ??
               throw new ObjectNotFoundException("Bus Stop with given expression not found");
    }

    public async Task<IEnumerable<BusStop>> GetAll(CancellationToken token)
    {
        return await _busStops.ToListAsync(token).ConfigureAwait(false);
    }
}