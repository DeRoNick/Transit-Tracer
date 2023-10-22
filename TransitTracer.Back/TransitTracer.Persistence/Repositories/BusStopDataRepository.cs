using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TransitTracer.Application.Infrastructure.Exceptions;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;
using TransitTracer.Persistence.Database;

namespace TransitTracer.Persistence.Repositories;

public class BusStopDataRepository : IBusStopDataRepository
{
    private readonly DbSet<BusStopData> _busStopData;

    public BusStopDataRepository(TransitTrackerDbContext context)
    {
        _busStopData = context.BusStopData;
    }
    
    public async Task InsertAsync(BusStopData data, CancellationToken token)
    {
        await _busStopData.AddAsync(data, token).ConfigureAwait(false);
    }

    public async Task<IEnumerable<BusStopData>> GetManyAsync(Expression<Func<BusStopData, bool>> expression, CancellationToken token)
    {
        return await _busStopData.Where(expression).ToListAsync(token).ConfigureAwait(false);
    }

    public async Task<BusStopData> GetAsync(Expression<Func<BusStopData, bool>> expression, CancellationToken token)
    {
        return await _busStopData.FirstOrDefaultAsync(expression, token).ConfigureAwait(false) 
               ?? throw new ObjectNotFoundException("No Bus Stop Data with given expression found");
    }

    public async Task<IEnumerable<BusStopData>> GetAll(CancellationToken token)
    {
        return await _busStopData.ToListAsync(token).ConfigureAwait(false);
    }
}