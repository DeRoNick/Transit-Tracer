using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Configurations;

public class BusConfiguration : IEntityTypeConfiguration<Bus>
{
    public void Configure(EntityTypeBuilder<Bus> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Car>(x => x.Car)
            .WithOne(x => x.Bus)
            .HasForeignKey<Bus>(x => x.CarId);
        
        builder.HasOne<Route>(x => x.Route)
            .WithMany(x => x.Buses)
            .HasForeignKey(x => x.RouteId);
    }
}