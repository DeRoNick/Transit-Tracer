using Microsoft.EntityFrameworkCore;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Database;

public class TransitTrackerDbContext : DbContext
{
    public DbSet<Bus> Buses { get; set; }
    public DbSet<BusStop> BusStops { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<RouteStop> RouteStops { get; set; }
    public DbSet<BusStopData> BusStopData { get; set; }

    public TransitTrackerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransitTrackerDbContext).Assembly);
    }
}