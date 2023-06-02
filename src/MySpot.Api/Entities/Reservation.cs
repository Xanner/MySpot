using MySpot.Api.Exceptions;

namespace MySpot.Api.Entities;

public class Reservation
{
    public Guid Id { get; }
    public Guid ParkingSpotId { get; }
    public string EmployeeName { get; private set; }
    public string LicensePlate { get; private set; }
    public DateTime Date { get; private set; }

    public Reservation(Guid id, Guid parkingSpotId, string employeeName, string licensePlate, DateTime date)
    {
        Id = id;
        ParkingSpotId = parkingSpotId;
        EmployeeName = employeeName;
        ChangeLicensePlate(licensePlate);
        Date = date;
    }

    public void ChangeLicensePlate(string licensePlate)
    {
        if (string.IsNullOrWhiteSpace(licensePlate))
        {
            throw new EmptyLicensePlateException();
        }

        LicensePlate = licensePlate;
    }
}
