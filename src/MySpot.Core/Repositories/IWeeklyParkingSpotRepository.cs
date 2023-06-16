using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Repositories;

public interface IWeeklyParkingSpotRepository
{
    Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id);
    Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week) => throw new NotImplementedException();
    Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync();
    Task AddAsync(WeeklyParkingSpot weeklyParkingSpot);
    Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot);
    Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot);
}
