using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;
using MySpot.Core.Repositories;
using System.Runtime.CompilerServices;
using MySpot.Core.Abstractions;

[assembly: InternalsVisibleTo("MySpot.Tests.Unit")]
namespace MySpot.Infrastructure.DAL.Repositories;

internal class InMemoryWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
{
    private readonly List<WeeklyParkingSpot> _weeklyParkingSpots;

    public InMemoryWeeklyParkingSpotRepository(IClock clock)
    {
        _weeklyParkingSpots = new()
        {
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(clock.Current()), "P1"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(clock.Current()), "P2"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(clock.Current()), "P3"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(clock.Current()), "P4"),
            WeeklyParkingSpot.Create(Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(clock.Current()), "P5")
        };
    }

    public Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id)
        => Task.FromResult(_weeklyParkingSpots.SingleOrDefault(x => x.Id == id));

    public Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync()
        => Task.FromResult(_weeklyParkingSpots.AsEnumerable());

    public Task AddAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        _weeklyParkingSpots.Add(weeklyParkingSpot);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot) => Task.CompletedTask;

    public Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot)
    {
        _weeklyParkingSpots.Remove(weeklyParkingSpot);
        return Task.CompletedTask;
    }
}
