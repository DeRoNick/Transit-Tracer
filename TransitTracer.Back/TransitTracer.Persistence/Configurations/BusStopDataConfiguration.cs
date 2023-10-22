using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Configurations;

public class BusStopDataConfiguration : IEntityTypeConfiguration<BusStopData>
{
    public void Configure(EntityTypeBuilder<BusStopData> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.In).IsRequired();
        
        builder.Property(x => x.Out).IsRequired();
        
        builder.Property(x => x.Cycle).IsRequired();
        
        builder.Property(x => x.Date).IsRequired();
        
        builder.Property(x => x.Current).IsRequired();
        
        builder.HasOne(x => x.BusStop)
            .WithMany(x => x.BusStopData)
            .HasForeignKey(x => x.BusStopId)
            .IsRequired();

        builder.HasOne<Route>(x => x.Route)
            .WithMany(x => x.BusStopData)
            .HasForeignKey(x => x.RouteId)
            .IsRequired();
    }
}