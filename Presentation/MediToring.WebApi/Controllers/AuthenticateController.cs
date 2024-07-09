using MediToring.Application.Features.Profiles.Commands.CreateProfile;
using MediToring.Domain.Models;
using MediToring.WebApi.Models.Request.Profiles;

namespace MediToring.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController(
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration,
    IMediator mediator,
    IMapper mapper
) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await userManager.FindByNameAsync(model.Username);
        if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
        {
            // мне вообще нужно сохранять username в claims???
            if (string.IsNullOrEmpty(user.UserName))
            {
                return BadRequest("User name cannot be null or empty");
            }

            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExists = await userManager.FindByNameAsync(model.Username);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

        IdentityUser user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details asn try again." });

        CreateProfileDto profile = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Height = model.Height,
            Weight = model.Weight
        };

        // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var command = mapper.Map<CreateProfileCommand>(profile);
        command.UserId = user.Id;

        Console.WriteLine($"Mapped CreateProfileCommand: {command.FirstName}, {command.LastName}, {command.DateOfBirth}, {command.Height}, {command.Weight}, {command.UserId}");

        var id = await mediator.Send(command);

        if (id == Guid.Empty)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = " Error", Message = "Create profile was failed" });

        return Ok(new Response { Status = "Success", Message = "User created successfully!" });
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var jwtSecret = configuration["JWT:Secret"];
        if (string.IsNullOrEmpty(jwtSecret))
        {
            throw new ConfigurationException("JWT Secret is not configured properly");
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

        var token = new JwtSecurityToken(
            issuer: configuration["JWT:ValidIssuer"],
            audience: configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}
