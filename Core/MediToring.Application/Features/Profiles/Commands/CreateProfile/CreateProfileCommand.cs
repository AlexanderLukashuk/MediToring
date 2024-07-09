namespace MediToring.Application.Features.Profiles.Commands.CreateProfile;

public class CreateProfileCommand : IRequest<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set;}
    public DateTime DateOfBirth { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public required string UserId { get; set; }
}