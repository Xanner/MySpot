using MySpot.Core.Entities;
using MySpot.Application.Services;
using MySpot.Core.ValueObjects;
using MySpot.Core.Repositories;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MySpot.Tests.Unit")]
namespace MySpot.Infrastructure.DAL.Repositories;

internal class InMemoryWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
{
    private readonly List<WeeklyParkingSpot> _weeklyParkingSpots;

    public InMemoryWeeklyParkingSpotRepository(IClock clock)
    {
        _weeklyParkingSpots = new()
        {
            new (Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(clock.Current()), "P1"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(clock.Current()), "P2"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(clock.Current()), "P3"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(clock.Current()), "P4"),
            new (Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(clock.Current()), "P5")
        };
    }

    public WeeklyParkingSpot Get(ParkingSpotId id)
        => _weeklyParkingSpots.SingleOrDefault(x => x.Id == id);

    public IEnumerable<WeeklyParkingSpot> GetAll()
        => _weeklyParkingSpots;


    public void Add(WeeklyParkingSpot weeklyParkingSpot)
        => _weeklyParkingSpots.Add(weeklyParkingSpot);

    public void Delete(WeeklyParkingSpot weeklyParkingSpot)
    {
    }

    public void Update(WeeklyParkingSpot weeklyParkingSpot)
        => _weeklyParkingSpots.Remove(weeklyParkingSpot);
}
