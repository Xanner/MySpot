using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public abstract class Reservation
{
    public ReservationId Id { get; private set; }
    public ParkingSpotId ParkingSpotId { get; private set; }
    public Date Date { get; private set; }

    protected Reservation()
    {
    }

    public Reservation(ReservationId id, ParkingSpotId parkingSpotId, Date date)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        Date = date;
    }
}
