namespace TransitTracer.Domain.Models;

public class BusStop
{
    public int Id { get; set; }
    public string Street { get; set; }

    public ICollection<RouteStop> RouteStops { get; set; }
    public ICollection<BusStopData> BusStopData { get; set; }
}