using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Policies;

internal sealed class BossReservationPolicy : IReservationPolicy
{
    public bool CanBeAplied(JobTitle jobTitle)
        => jobTitle == JobTitle.Boss;

    public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
        => true;
}
