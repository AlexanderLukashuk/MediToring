using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Queries.Models;

public class UserProfileDto : IMapWith<UserProfile>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set;}
    public DateTime DateOfBirth { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public required string UserId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserProfile, UserProfileDto>();
    }
}