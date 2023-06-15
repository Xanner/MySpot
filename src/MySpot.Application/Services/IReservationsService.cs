using MySpot.Application.Commands;
using MySpot.Application.DTO;

namespace MySpot.Application.Services;

public interface IReservationsService
{
    Task<ReservationDto> GetAsync(Guid id);
    Task<IEnumerable<ReservationDto>> GetAllWeeklyAsync();
    Task<Guid?> CreateAsync(CreateReservation command);
    Task<bool> UpdateAsync(ChangeReservationLicensePlate command);
    Task<bool> DeleteAsync(DeleteReservation command);
}
