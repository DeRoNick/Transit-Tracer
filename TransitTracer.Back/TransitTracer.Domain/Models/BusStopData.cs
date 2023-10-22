namespace TransitTracer.Domain.Models;

public class BusStopData
{
    public int Id { get; set; }
    
    public int BusStopId { get; set; }
    public BusStop BusStop { get; set; }
    
    public int In { get; set; }
    public int Out { get; set; }
    public int Current { get; set; }
    public int Cycle { get; set; }
    public DateTime Date { get; set; } 
    
    public int RouteId { get; set; }
    public Route Route { get; set; }
}