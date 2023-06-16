using MySpot.Core.Repositories;
using MySpot.Application.Commands;
using MySpot.Application.Services;
using MySpot.Tests.Unit.Shared;
using Shouldly;
using Xunit;
using MySpot.Infrastructure.DAL.Repositories;
using MySpot.Core.Abstractions;
using MySpot.Core.DomainServices;
using MySpot.Core.Policies;

namespace MySpot.Tests.Unit.Services;

public class ReservationServiceTests
{
    [Fact]
    public async Task given_reservation_for_not_taken_date_create_reservation_should_succed()
    {
        var weeklyParkingSpot = (await _weeklyParkingSpotRepository.GetAllAsync()).First();
        var command = new ReserveParkingSpotForVehicle(weeklyParkingSpot.Id,
            Guid.NewGuid(), 1, DateTime.UtcNow.AddMinutes(5), "John Doe", "XYZ123");

        var reservationId = await _reservationsService.ReserveForVehicleAsync(command);

        //reservationId.ShouldNotBeNull();
        //reservationId.Value.ShouldBe(command.ReservationId);
    }

    #region Arrange

    private readonly IClock _clock;
    private readonly IWeeklyParkingSpotRepository _weeklyParkingSpotRepository;
    private readonly IReservationsService _reservationsService;

    public ReservationServiceTests()
    {
        _clock = new TestClock();
        _weeklyParkingSpotRepository = new InMemoryWeeklyParkingSpotRepository(_clock);

        var parkingReservationService = new ParkingReservationService(new IReservationPolicy[]
        {
            new RegularEmployeeReservationPolicy(_clock),
            new ManagerReservationPolicy(),
            new BossReservationPolicy()
        }, _clock);

        _reservationsService = new ReservationsService(_clock, _weeklyParkingSpotRepository, parkingReservationService);
    }

    #endregion
}