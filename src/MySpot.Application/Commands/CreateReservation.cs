namespace MySpot.Application.Commands;

public record CreateReservation(Guid ParkingSpotId, Guid ReservationId, DateTime Date,
    string EmployeeName, string LicensePlate);