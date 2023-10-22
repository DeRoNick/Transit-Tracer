using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Configurations;

public class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
{
    public void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Route>(x => x.Route)
            .WithMany(x => x.Stops)
            .HasForeignKey(x => x.RouteId)
            .IsRequired();

        builder.HasOne<BusStop>(x => x.Stop)
            .WithMany(x => x.RouteStops)
            .HasForeignKey(x => x.StopId)
            .IsRequired();

        builder.Property(x => x.Order)
            .IsRequired();
    }
}