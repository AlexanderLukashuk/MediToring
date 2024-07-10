using MediToring.Application.Features.Profiles.Queries.Models;

namespace MediToring.Application.Features.Profiles.Queries.GetProfile;

public class GetProfileQuery : IRequest<UserProfileDto>
{
    public required string UserId { get; set; }
}