using MediToring.Application.Features.Profiles.Queries.Models;

namespace MediToring.Application.Features.Profiles.Queries.GetAllDoctors;

public class GetDoctorProfilesQueryHandler(IProfileRepository repository, IMapper mapper) 
    : IRequestHandler<GetAllDoctorsQuery, List<UserProfileDto>>
{
    public async Task<List<UserProfileDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
    {
        var doctors = await repository.GetAllDoctors(cancellationToken);

        return mapper.Map<List<UserProfileDto>>(doctors);
    }
}