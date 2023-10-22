namespace TransitTracer.Domain.Models;

public class Car
{
    public int Id { get; set; }
    public string Plate { get; set; }

    public int BusId { get; set; }
    public Bus Bus { get; set; }
}