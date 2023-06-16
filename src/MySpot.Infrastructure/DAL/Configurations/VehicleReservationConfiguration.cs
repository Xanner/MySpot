using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Configurations;

internal sealed class VehicleReservationConfiguration : IEntityTypeConfiguration<VehicleReservation>
{
    public void Configure(EntityTypeBuilder<VehicleReservation> builder)
    {
        builder.Property(x => x.EmployeeName)
            .HasConversion(x => x.Value, x => new EmployeeName(x));
        builder.Property(x => x.LicensePlate)
            .HasConversion(x => x.Value, x => new LicensePlate(x));
    }
}
