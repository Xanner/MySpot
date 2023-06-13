using MySpot.Api.Exceptions;

namespace MySpot.Api.Exceptions;

public class InvalidParkingSpotNameException : CustomException
{
    public InvalidParkingSpotNameException() : base("Parking spot name is invalid.")
    {
    }
}