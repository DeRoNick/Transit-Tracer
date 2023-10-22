using MediatR;
using TransitTracer.Application.Infrastructure.Repositories;

namespace TransitTracer.Application.Tracer.Queries;

public class BusLocationQuery : IRequest<ICollection<string>>
{
    public int RouteId { get; }

    public BusLocationQuery(int id)
    {
        RouteId = id;
    }
}

public class BusLocationQueryHandler : IRequestHandler<BusLocationQuery, ICollection<string>>
{
    private readonly IBusStopDataRepository _repo;

    public BusLocationQueryHandler(IBusStopDataRepository repo)
    {
        _repo = repo;
    }

    public async Task<ICollection<string>> Handle(BusLocationQuery request, CancellationToken cancellationToken)
    {
        var busData = await _repo.GetManyAsync(
                x => x.RouteId == request.RouteId 
                     && x.Date.ToShortDateString() == DateTime.Now.ToShortDateString(), cancellationToken)
            .ConfigureAwait(false);

        return busData.Select(data => data.BusStop.Street).ToList();
    }
}