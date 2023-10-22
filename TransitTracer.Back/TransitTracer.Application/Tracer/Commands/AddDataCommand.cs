using MediatR;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;

namespace TransitTracer.Application.Tracer.Commands;

public class AddDataCommand : IRequest
{
    public int RouteId { get; set; }
    public int StopId { get; set; }
    public int Entered { get; set; }
    public int Exited { get; set; }
    public int Cycle { get; set; }
}

public class AddDataCommandHandler : IRequestHandler<AddDataCommand>
{
    private readonly IBusStopDataRepository _repo;

    public AddDataCommandHandler(IBusStopDataRepository repo)
    {
        _repo = repo;
    }

    public async Task Handle(AddDataCommand request, CancellationToken cancellationToken)
    {
        await _repo.InsertAsync(new BusStopData
        {
            BusStopId = request.StopId,
            In = request.Entered,
            Out = request.Exited,
            Cycle = request.Cycle,
            Date = DateTime.Now,
            RouteId = request.RouteId
        }, cancellationToken).ConfigureAwait(false);
    }
}