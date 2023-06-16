using MySpot.Core.Entities;
using MySpot.Core.Exceptions;
using MySpot.Core.ValueObjects;
using Shouldly;
using Xunit;

namespace MySpot.Tests.Unit.Entities;

public class WeeklyParkingSpotTests
{
    [Theory]
    [InlineData("2022-08-09")]
    [InlineData("2022-08-17")]
    public void given_invalid_date_add_reservation_should_fail(string dateString)
    {
        var invalidDate = DateTime.Parse(dateString);
        var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", new Date(invalidDate));

        var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, new Date(_now)));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<InvalidReservationDateException>();
    }

    [Fact]
    public void given_reservation_for_already_existing_date_add_reservation_should_fail()
    {
        var reservationDate = _now.AddDays(1);
        var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);
        _weeklyParkingSpot.AddReservation(reservation, _now);
        var nextReservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);

        var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(nextReservation, reservationDate));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<ParkingSpotAlreadyReservedException>();
    }

    [Fact]
    public void given_reservation_for_not_taken_date_add_reservation_should_succed()
    {
        var reservationDate = _now.AddDays(1);
        var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe", "XYZ123", reservationDate);

        _weeklyParkingSpot.AddReservation(reservation, _now);

        _weeklyParkingSpot.Reservations.ShouldHaveSingleItem();
    }

    #region Arange

    private readonly Date _now;
    private readonly WeeklyParkingSpot _weeklyParkingSpot;

    public WeeklyParkingSpotTests()
    {
        _now = new Date(new DateTime(2022, 08, 10));
        _weeklyParkingSpot = new WeeklyParkingSpot(Guid.NewGuid(), new Week(_now), "P1");
    }

    #endregion
}