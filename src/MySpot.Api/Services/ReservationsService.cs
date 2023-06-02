using MySpot.Api.Entities;

namespace MySpot.Api.Services;

public class ReservationsService
{
    private static List<WeeklyParkingSpot> WeeklyParkingSpots = new()
    {
        new WeeklyParkingSpot(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(7), "P1"),
        new WeeklyParkingSpot(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(7), "P2"),
        new WeeklyParkingSpot(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(7), "P3"),
        new WeeklyParkingSpot(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(7), "P4"),
        new WeeklyParkingSpot(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow.AddDays(7), "P5")
    };

    public Reservation Get(Guid id)
        => GetAllWeekly().SingleOrDefault(x => x.Id == id);

    public IEnumerable<Reservation> GetAllWeekly() 
        => WeeklyParkingSpots.SelectMany(x => x.Reservations);

    public Guid? Create(Reservation reservation)
    {
        var weeklyParkingSpot = WeeklyParkingSpots.SingleOrDefault(x => x.Id == reservation.ParkingSpotId);
        if(weeklyParkingSpot is null)
        {
            return default;
        }

        reservation.Id = Guid.NewGuid();
        weeklyParkingSpot.AddReservation(reservation);

        return reservation.Id;
    }

    public bool Update(int id, Reservation reservation)
    {
        var existingReservation = Reservations.SingleOrDefault(x => x.Id == id);
        if (existingReservation is null)
        {
            return false;
        }

        if(existingReservation.Date < DateTime.UtcNow)
        {
            return false;
        }

        existingReservation.LicensePlate = reservation.LicensePlate;

        return true;
    }

    public bool Delete(int id)
    {
        var existingReservation = Reservations.SingleOrDefault(x => x.Id == id);
        if (existingReservation is null)
        {
            return false;
        }

        Reservations.Remove(existingReservation);

        return true;
    }
}
