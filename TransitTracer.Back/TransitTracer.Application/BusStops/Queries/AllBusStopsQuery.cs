using MediatR;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;

namespace TransitTracer.Application.BusStops.Queries;

public class AllBusStopsQuery : IRequest<IEnumerable<BusStop>>
{
}

public class AllBusStopsQueryHandler : IRequestHandler<AllBusStopsQuery, IEnumerable<BusStop>>
{
    private readonly IBusStopRepository _repo;

    public AllBusStopsQueryHandler(IBusStopRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<BusStop>> Handle(AllBusStopsQuery request, CancellationToken cancellationToken)
    {
        return await _repo.GetAll(cancellationToken).ConfigureAwait(false);
    }
}