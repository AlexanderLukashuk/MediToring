using MediToring.Application.Features.Profiles.Commands.ApproveDoctor;
using MediToring.Application.Features.Profiles.Commands.CreateDoctorProfile;
using MediToring.Application.Features.Profiles.Queries.GetAllDoctorsApplications;
using MediToring.WebApi.Models;
using MediToring.WebApi.Models.Request.Doctors;

namespace MediToring.WebApi.Controllers;

[Authorize(Policy = "UserPolicy")]
[ApiController]
[Route("api/[controller]")]
public class AdminController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("approve-doctor")]
    public async Task<IActionResult> ApproveDoctor([FromBody] ApproveDoctorDto model)
    {
        var command = new ApproveDoctorCommand { ApplicationId = model.ApplicationId };
        await mediator.Send(command);
        return Ok(new { Status = "Success", Message = "Doctor approved successfully!" });
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("applications")]
    public async Task<IActionResult> GetAllApplications()
    {
        var applications = await mediator.Send(new GetDoctorApplicationsQuery());
        return Ok(applications);
    }
}