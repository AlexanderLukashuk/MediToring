namespace MediToring.WebApi.Controllers;

[Authorize(Policy = "UserPolicy")]
[ApiController]
[Route("api/[controller]")]
public class MedicationScheduleController(IMapper mapper, IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<MedicationScheduleVm>>> GetAll()
    {
        var query = new GetUserMedicationSchedulesQuery { UserId = UserId };
        var vm = await mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<MedicationScheduleVm>> Get(Guid id)
    {
        var query = new GetUserMedicationSchedulesForMedicationQuery { UserId = UserId, ScheduleId = id };
        var vm = await mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicationScheduleDto dto)
    {
        var command = mapper.Map<UpdateScheduleCommand>(dto);
        command.Id = id;
        command.UserId = UserId;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
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