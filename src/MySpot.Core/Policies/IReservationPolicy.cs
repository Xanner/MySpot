using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Policies;

public interface IReservationPolicy
{
    bool CanBeAplied(JobTitle jobTitle);
    bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName);
}
