using MediToring.Application.Features.Profiles.Commands.CreateDoctorApplication;
using MediToring.WebApi.Models.Request.Doctors;

namespace MediToring.WebApi.Controllers;

[Authorize(Policy = "UserPolicy")]
[ApiController]
[Route("api/[controller]")]
public class DoctorApplicationController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    // [Authorize(Roles = "User")]
    [Route("apply")]
    public async Task<IActionResult> ApplyForDoctor([FromBody] DoctorApplicationDto model)
    {
        var command = new CreateDoctorApplicationCommand
        {
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Specialization = model.Specialization,
            Qualification = model.Qualification,
            ExperienceYears = model.ExperienceYears,
            Clinic = model.Clinic,
            Bio = model.Bio
        };

        var result = await mediator.Send(command);
        return Ok(new Response { Status = "Success", Message = "Application submitted successfully!" });
    }

    // [HttpGet]
    // [Authorize(Roles = "Admin")]
    // [Route("all-applications")]
    // public Task<IActionResult> GetApplications()
    // {

    // }
}