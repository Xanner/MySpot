using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Configurations;

internal sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new ReservationId(x));
        builder.Property(x => x.ParkingSpotId)
            .HasConversion(x => x.Value, x => new ParkingSpotId(x));
        builder.Property(x => x.EmployeeName)
            .HasConversion(x => x.Value, x => new EmployeeName(x));
        builder.Property(x => x.LicensePlate)
            .HasConversion(x => x.Value, x => new LicensePlate(x));
        builder.Property(x => x.Date)
            .HasConversion(x => x.Value, x => new Date(x));
    }
}
