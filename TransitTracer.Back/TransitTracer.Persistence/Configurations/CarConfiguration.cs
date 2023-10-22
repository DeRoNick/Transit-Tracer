using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransitTracer.Domain.Models;

namespace TransitTracer.Persistence.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Plate)
            .HasMaxLength(7)
            .IsRequired();
    }
}