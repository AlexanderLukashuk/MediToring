using MediToring.Application.Common.Exceptions;

namespace MediToring.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicationController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<List<MedicationListVm>>> GetAll()
    {
        var query = new GetMedicationListQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<MedicationDetailsVm>> Get(Guid id)
    {
        try
        {
            var query = new GetMedicationDetailsQuery { Id = id };
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateMedicationDto dto)
    {
        var command = mapper.Map<CraeteMedicationCommand>(dto);
        var id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMedicationDto dto)
    {
        var command = mapper.Map<UpdateMedicationCommand>(dto);
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteMedicationCommand { Id = id };
        await mediator.Send(command);
        return NoContent();
    }
}