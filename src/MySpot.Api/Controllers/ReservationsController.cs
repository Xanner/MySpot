using Microsoft.AspNetCore.Mvc;
using MySpot.Application.Commands;
using MySpot.Application.DTO;
using MySpot.Application.Services;

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
    public async Task<ActionResult<IEnumerable<ReservationDto>>> Get() 
        => Ok(await _reservationsService.GetAllWeeklyAsync());

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReservationDto>> Get(Guid id)
    {
        var reservation = await _reservationsService.GetAsync(id);
        if (reservation is null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }

    [HttpPost("vehicle")]
    public async Task<ActionResult> Post(ReserveParkingSpotForVehicle command)
    {
        var id = await _reservationsService.ReserveForVehicleAsync(command with { ReservationId = Guid.NewGuid()});
        if (id is null)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Get), new { id }, null);
    }

    [HttpPost("cleaning")]
    public async Task<ActionResult> Post(ReserveParkingSpotForCleaning command)
    {
        await _reservationsService.ReserveForCleaningAsync(command);

        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(Guid id, ChangeReservationLicensePlate command)
    {
        if(await _reservationsService.ChangeReservationLicensePlateAsync(command with { ReservationId = id}))
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        if (await _reservationsService.DeleteAsync(new DeleteReservation(id)))
        {
            return NoContent();
        }

        return NotFound();
    }
}
