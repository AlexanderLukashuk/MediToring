using MediToring.Application.Features.Profiles.Commands.UpdateProfile;

namespace MediToring.WebApi.Models.Request.Profiles;

public class UpdateProfileDto : IMapWith<UpdateProfileCommand>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProfileDto, UpdateProfileCommand>();
    }
}