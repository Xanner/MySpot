using MySpot.Core.ValueObjects;

namespace MySpot.Core.Exceptions;

public sealed class ParkingSpotCapacityExceededExcepetion : CustomException
{
    public ParkingSpotId ParkingSpotId { get; }

    public ParkingSpotCapacityExceededExcepetion(ParkingSpotId parkingSpotId) 
        : base($"Parking spot with ID: {parkingSpotId} exceeds its reservation capacity.")
    {
        ParkingSpotId = parkingSpotId;
    }
}
