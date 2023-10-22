namespace TransitTracer.Domain.Models;

public class RouteStop
{
    public int Id { get; set; }
    
    public int RouteId { get; set; }
    public Route Route { get; set; }
    
    public int StopId { get; set; }
    public BusStop Stop { get; set; }
    
    public int Order { get; set; }
}