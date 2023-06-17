using MySpot.Application.Abstractions;
using MySpot.Core.Entities;
using MySpot.Core.Repositories;
using MySpot.Core.ValueObjects;
using MySpot.Application.Exceptions;

namespace MySpot.Application.Commands.Handlers;

internal sealed class ChangeReservationLicensePlateHandler : ICommandHandler<ChangeReservationLicensePlate>
{
    private readonly IWeeklyParkingSpotRepository _repository;

    public ChangeReservationLicensePlateHandler(IWeeklyParkingSpotRepository repository)
        => _repository = repository;

    public async Task HandleAsync(ChangeReservationLicensePlate command)
    {
        var weeklyParkingSpot = await GetWeeklyParkingSpotByReservation(command.ReservationId);
        if (weeklyParkingSpot is null)
        {
            throw new WeeklyParkingSpotNotFoundException();
        }

        var reservationId = new ReservationId(command.ReservationId);
        var existingReservation = weeklyParkingSpot.Reservations
            .OfType<VehicleReservation>()
            .SingleOrDefault(x => x.Id == reservationId);

        if (existingReservation is null)
        {
            throw new ReservationNotFoundException(command.ReservationId);
        }

        existingReservation.ChangeLicensePlate(command.LicensePlate);
        await _repository.UpdateAsync(weeklyParkingSpot);
    }

    private async Task<WeeklyParkingSpot> GetWeeklyParkingSpotByReservation(ReservationId id)
        => (await _repository.GetAllAsync())
            .SingleOrDefault(x => x.Reservations.Any(r => r.Id == id)); 
}
