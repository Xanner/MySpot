using MySpot.Api.Commands;
using MySpot.Api.DTO;

namespace MySpot.Api.Services;

public interface IReservationsService
{
    ReservationDto Get(Guid id);
    IEnumerable<ReservationDto> GetAllWeekly();
    Guid? Create(CreateReservation command);
    bool Update(ChangeReservationLicensePlate command);
    bool Delete(DeleteReservation command);
}
