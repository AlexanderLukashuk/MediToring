using MediToring.Application.Features.Profiles.Queries.Models;
using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Queries.GetProfile;

public class GetProfileQueryHandler(IProfileRepository repository, IMapper mapper) 
    : IRequestHandler<GetProfileQuery, UserProfileDto>
{
    public async Task<UserProfileDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {
        var profile = await repository.GetByUserId(request.UserId);

        if (profile == null)
        {
            throw new NotFoundException(nameof(UserProfile), request.UserId);
        }

        return mapper.Map<UserProfileDto>(profile);
    }
}