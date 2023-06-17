using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands;

public record DeleteReservation(Guid ReservationId) : ICommand;
