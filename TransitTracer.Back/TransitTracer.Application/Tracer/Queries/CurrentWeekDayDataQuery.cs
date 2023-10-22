using MediatR;
using TransitTracer.Application.Infrastructure.Repositories;
using TransitTracer.Domain.Models;

namespace TransitTracer.Application.Tracer.Queries;

public class CurrentWeekDayDataQuery : IRequest<Dictionary<string,
    Dictionary<int,
        Dictionary<int,
            Dictionary<int, ICollection<StopData>>>>>>
{
    
}

public class StopData
{
    public int In { get; set; }
    public int Out { get; set; }
    public int Current { get; set; }
}

public class CurrentWeekDayDataQueryHandler : IRequestHandler<CurrentWeekDayDataQuery, Dictionary<string,
    Dictionary<int,
        Dictionary<int,
            Dictionary<int, ICollection<StopData>>>>>>
{
    private readonly IBusStopDataRepository _repo;

    public CurrentWeekDayDataQueryHandler(IBusStopDataRepository repo)
    {
        _repo = repo;
    }

    public async Task<Dictionary<string,
        Dictionary<int,
            Dictionary<int,
                Dictionary<int, ICollection<StopData>>>>>> Handle(CurrentWeekDayDataQuery request, CancellationToken cancellationToken)
    {
        var data = await _repo.GetAll(cancellationToken)
            .ConfigureAwait(false);

        var result = new Dictionary<string,
            Dictionary<int,
                Dictionary<int,
                    Dictionary<int, ICollection<StopData>>>>>();
        
        foreach (var day in Enum.GetNames(typeof(DayOfWeek)))
        {
            result[day] = new Dictionary<int, Dictionary<int, Dictionary<int, ICollection<StopData>>>>();
            var dayData = data.Where(d => d.Date.DayOfWeek.ToString() == day);
            foreach (var busStopData in dayData)
            {
                if (!result[day].ContainsKey(busStopData.RouteId))
                {
                    result[day][busStopData.RouteId] = new Dictionary<int, Dictionary<int, ICollection<StopData>>>();
                }

                if (!result[day][busStopData.RouteId].ContainsKey(busStopData.Cycle))
                {
                    result[day][busStopData.RouteId][busStopData.Cycle] = new Dictionary<int, ICollection<StopData>>();
                }
                
                if (!result[day][busStopData.RouteId][busStopData.Cycle].ContainsKey(busStopData.BusStopId))
                {
                    result[day][busStopData.RouteId][busStopData.Cycle][busStopData.BusStopId] = new List<StopData>();
                }
                
                result[day][busStopData.RouteId][busStopData.Cycle][busStopData.BusStopId].Add(new StopData
                {
                    In = busStopData.In,
                    Out = busStopData.Out,
                    Current = busStopData.Current
                });
            }
        }

        return result;
    }
}