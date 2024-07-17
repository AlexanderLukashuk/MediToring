using MediToring.Application.Features.Profiles.Commands.CreateDoctorProfile;
using MediToring.WebApi.Models;
using MediToring.WebApi.Models.Request.Doctors;

namespace MediToring.WebApi.Controllers;

[Authorize(Policy = "UserPolicy")]
[ApiController]
[Route("api/[controller]")]
public class AdminController(
    UserManager<IdentityUser> userManager, 
    RoleManager<IdentityRole> roleManager, 
    IMediator mediator) 
    : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("approve-doctor")]
    public async Task<IActionResult> ApproveDoctor([FromBody] ApproveDoctorDto model)
    {
        if (string.IsNullOrEmpty(model.UserId))
        {
            // правильно ли тут возвращать 500 ошибку?????
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User id can't be null or empty" });
        }

        var user = await userManager.FindByIdAsync(model.UserId); // мб переделать позже на поиск по имени
        if (user == null)
        {
            return NotFound(new Response { Status = "Error", Message = "User not found" });
        }

        if (!await roleManager.RoleExistsAsync(UserRoles.Doctor))
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Doctor));
        
        if (await roleManager.RoleExistsAsync(UserRoles.Doctor))
        {
            await userManager.AddToRoleAsync(user, UserRoles.Doctor);
        }

        // var result = await userManager.AddToRoleAsync(user, UserRoles.Doctor);
        // if (!result.Succeeded)
        // {
        //     return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to assign Doctor role" });
        // }

        var command = new CreateDoctorProfileCommand
        {
            UserProfileId = model.UserProfileId,
            Specialization = model.Specialization,
            Qualification = model.Qualification,
            ExperienceYears = model.ExperienceYears,
            Clinic = model.Clinic,
            Bio = model.Bio
        };

        await mediator.Send(command);
        return Ok(new Response { Status = "Succes", Message = "Doctor approved successfully!" });
    }
}