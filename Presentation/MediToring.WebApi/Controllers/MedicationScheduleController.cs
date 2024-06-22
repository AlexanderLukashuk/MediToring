namespace MediToring.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicationScheduleController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<MedicationScheduleVm>>> GetAll()
    {
        var query = new GetUserMedicationSchedulesQuery { UserId = UserId };
        var vm = await mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<MedicationScheduleVm>> Get(Guid id)
    {
        var query = new GetUserMedicationSchedulesForMedicationQuery { UserId = UserId, MedicationId = id };
        var vm = await mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMedicationScheduleDto dto)
    {
        var command = mapper.Map<CreateScheduleCommand>(dto);
        command.UserId = UserId;
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicationScheduleDto dto)
    {
        dto.Id = id;
        var command = mapper.Map<UpdateScheduleCommand>(dto);
        command.UserId = UserId;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteScheduleCommand { Id = id }; // UserId????
        await mediator.Send(command);
        return NoContent();
    }

    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}