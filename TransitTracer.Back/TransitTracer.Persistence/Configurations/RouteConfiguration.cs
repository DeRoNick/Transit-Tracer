using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.RouteNumber)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(30);
    }
}