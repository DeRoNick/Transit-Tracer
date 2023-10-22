using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Configurations;

public class BusStopConfiguration : IEntityTypeConfiguration<BusStop>
{
    public void Configure(EntityTypeBuilder<BusStop> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Street)
            .HasMaxLength(50);
    }
}