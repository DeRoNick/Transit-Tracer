using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransitTracer.Application.Tracer.Commands;
using TransitTracer.Application.Tracer.Queries;
using TransitTracer.Domain.Models;

namespace TransitTracer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TracerController : ControllerBase
{
    private readonly IMediator _mediator;

    public TracerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("data")]
    public async Task AddData([FromBody] AddDataCommand command)
    {
        await _mediator.Send(command).ConfigureAwait(false);
    }

    [HttpGet("data")]
    public async Task<Dictionary<string,
        Dictionary<int,
            Dictionary<int,
                Dictionary<int, ICollection<StopData>>>>>> GetWeekData()
    {
        return await _mediator.Send(new CurrentWeekDayDataQuery()).ConfigureAwait(false);
    }
}