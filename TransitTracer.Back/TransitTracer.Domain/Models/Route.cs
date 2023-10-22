namespace TransitTracer.Domain.Models;

public class Route
{
    public int Id { get; set; }
    public int RouteNumber { get; set; }
    public string Name { get; set; }

    public ICollection<Bus> Buses { get; set; }
    public ICollection<RouteStop> Stops { get; set; }
    public ICollection<BusStopData> BusStopData { get; set; }
}