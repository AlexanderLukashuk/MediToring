using MediToring.Application.Features.Profiles.Commands.UpdateProfile;
using MediToring.Application.Features.Profiles.Queries.GetAllDoctors;
using MediToring.Application.Features.Profiles.Queries.GetProfile;
using MediToring.WebApi.Models.Request.Profiles;

namespace MediToring.WebApi.Controllers;

[Authorize(Policy = "UserPolicy")]
[ApiController]
[Route("api/[controller]")]
public class ProfileController(IMediator mediator, IMapper mapper) : ControllerBase
{
    [HttpGet("current")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetCurrentProfile()
    {
        var query = new GetProfileQuery { UserId = UserId };
        var profile = await mediator.Send(query);
        return Ok(profile);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetProfile(string id)
    {
        var query = new GetProfileQuery { UserId = id };
        var profile = await mediator.Send(query);
        return Ok(profile);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProfileDto dto)
    {
        var command = mapper.Map<UpdateProfileCommand>(dto);
        command.Id = id;
        command.UserId = UserId;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> GetAllDoctors()
    {
        var query = new GetAllDoctorsQuery();
        var result = await mediator.Send(query);
        return Ok(result);
    }

    private string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
}