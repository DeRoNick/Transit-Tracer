using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransitTracer.Application.BusStops.Queries;
using TransitTracer.Application.Routes.Queries;
using TransitTracer.Application.Tracer.Queries;
using TransitTracer.Domain;
using TransitTracer.Domain.Models;
using Route = TransitTracer.Domain.Models.Route;

namespace TransitTracer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BusController : ControllerBase
{
    private readonly IMediator _mediator;

    public BusController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("routes")]
    public async Task<IEnumerable<Route>> GetRoutes()
    {
        return await _mediator.Send(new AllRoutesQuery()).ConfigureAwait(false);
    }

    [HttpGet("stops")]
    public async Task<IEnumerable<BusStop>> GetBusStops()
    {
        return await _mediator.Send(new AllBusStopsQuery()).ConfigureAwait(false);
    }
    
    [HttpGet("location/{routeId}")]
    public async Task<ICollection<string>> GetBusLocations(int routeId)
    {
        return await _mediator.Send(new BusLocationQuery(routeId)).ConfigureAwait(false);
    }
    
    [HttpGet("capacity-now/{routeId}")]
    public async Task<BusCapacity> GetBusCapacityNow(int routeId)
    {
        return await _mediator.Send(new BusCapacityNowQuery(routeId)).ConfigureAwait(false);
    }
}