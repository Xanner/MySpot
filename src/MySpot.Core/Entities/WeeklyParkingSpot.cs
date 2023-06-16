using MySpot.Core.Exceptions;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public class WeeklyParkingSpot
{
    public const int MaxCapacity = 2;

    private readonly HashSet<Reservation> _reservations = new();

    public ParkingSpotId Id { get; private set; }
    public Week Week { get; private set; }
    public ParkingSpotName Name { get; private set; }
    public Capacity Capacity { get; private set; }
    public IEnumerable<Reservation> Reservations => _reservations;

    private WeeklyParkingSpot(ParkingSpotId id, Week week, ParkingSpotName name, Capacity capacity)
    {
        Id = id;
        Week = week;
        Name = name;
        Capacity = capacity;
    }

    public static WeeklyParkingSpot Create(ParkingSpotId id, Week week, ParkingSpotName name)
        => new WeeklyParkingSpot(id, week, name, MaxCapacity);

    internal void AddReservation(Reservation reservation, Date now)
    {
        var isInvalidDate = reservation.Date < Week.From ||
                            reservation.Date > Week.To ||
                            reservation.Date < now;

        if (isInvalidDate)
        {
            throw new InvalidReservationDateException(reservation.Date.Value.Date);
        }

        var dateCapacity = _reservations
            .Where(x => x.Date == reservation.Date)
            .Sum(x => x.Capacity);

        if(dateCapacity + reservation.Capacity > Capacity)
        {
            throw new ParkingSpotCapacityExceededExcepetion(Id);
        }

        _reservations.Add(reservation);
    }

    public void RemoveReservation(ReservationId reservationId)
        => _reservations.RemoveWhere(x => x.Id == reservationId);

    public void RemoveReservations(IEnumerable<Reservation> reservations)
        => _reservations.RemoveWhere(x => reservations.Any(r => r.Id == x.Id));
}
