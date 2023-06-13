using Microsoft.AspNetCore.Mvc;
using MySpot.Api.Commands;
using MySpot.Api.DTO;
using MySpot.Api.Services;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly IReservationsService _reservationsService;

    public ReservationsController(IReservationsService reservationsService)
    {
        _reservationsService = reservationsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReservationDto>> Get() => Ok(_reservationsService.GetAllWeekly());

    [HttpGet("{id:guid}")]
    public ActionResult<ReservationDto> Get(Guid id)
    {
        var reservation = _reservationsService.Get(id);
        if (reservation is null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }

    [HttpPost]
    public ActionResult Post(CreateReservation command)
    {
        var id = _reservationsService.Create(command with { ReservationId = Guid.NewGuid()});
        if (id is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPut("{id:guid}")]
    public ActionResult Put(Guid id, ChangeReservationLicensePlate command)
    {
        if(_reservationsService.Update(command with { ReservationId = id}))
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        if (_reservationsService.Delete(new DeleteReservation(id)))
        {
            return NoContent();
        }

        return NotFound();
    }
}
