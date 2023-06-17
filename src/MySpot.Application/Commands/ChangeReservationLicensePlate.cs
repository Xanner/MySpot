using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public record ChangeReservationLicensePlate(Guid ReservationId, string LicensePlate) : ICommand;
