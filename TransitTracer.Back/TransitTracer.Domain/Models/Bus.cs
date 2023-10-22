namespace TransitTracer.Domain.Models;

public class Bus
{
    public int Id { get; set; }
    
    public int CarId { get; set; }
    public Car Car { get; set; }
    
    public int RouteId { get; set; }
    public Route Route { get; set; }
}