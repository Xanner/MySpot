using MySpot.Api.ValueObjects;

namespace MySpot.Api.Entities;

public class Reservation
{
    public ReservationId Id { get; }
    public ParkingSpotId ParkingSpotId { get; }
    public EmployeeName EmployeeName { get; private set; }
    public LicensePlate LicensePlate { get; private set; }
    public Date Date { get; private set; }

    public Reservation(ReservationId id, ParkingSpotId parkingSpotId, EmployeeName employeeName, LicensePlate licensePlate, Date date)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        EmployeeName = employeeName;
        ChangeLicensePlate(licensePlate);
        Date = date;
    }

    public void ChangeLicensePlate(LicensePlate licensePlate) 
        => LicensePlate = licensePlate;
}
