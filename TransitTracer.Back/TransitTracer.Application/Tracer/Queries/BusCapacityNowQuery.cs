using MediatR;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain;

namespace TransitTracer.Application.Tracer.Queries;

public class BusCapacityNowQuery : IRequest<BusCapacity>
{
    public int BusId { get; set; }

    public BusCapacityNowQuery(int busId)
    {
        BusId = busId;
    }
}

public class BusCapacityNowQueryHandler : IRequestHandler<BusCapacityNowQuery, BusCapacity>
{
    private readonly IBusStopDataRepository _repo;

    public BusCapacityNowQueryHandler(IBusStopDataRepository repo)
    {
        _repo = repo;
    }

    public async Task<BusCapacity> Handle(BusCapacityNowQuery request, CancellationToken cancellationToken)
    {
        var data = await _repo.GetManyAsync(
            x => x.RouteId == request.BusId 
                 && x.Date.ToShortDateString() == DateTime.Now.ToShortDateString(), cancellationToken).ConfigureAwait(false);

        var numPeople = data.OrderBy(x => x.Date).Last().Current;

        if (numPeople < 30)
        {
            return BusCapacity.Low;
        } else if (numPeople < 60)
        {
            return BusCapacity.Medium;
        } else
        {
            return BusCapacity.High;
        }
    }
}