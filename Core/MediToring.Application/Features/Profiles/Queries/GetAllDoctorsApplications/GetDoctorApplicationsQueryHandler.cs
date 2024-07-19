using MediToring.Application.Features.Profiles.Queries.Models;

namespace MediToring.Application.Features.Profiles.Queries.GetAllDoctorsApplications;

public class GetDoctorApplicationsQueryHandler(IDoctorApplicationRepository repository, IMapper mapper) 
    : IRequestHandler<GetDoctorApplicationsQuery, List<DoctorApplicationDto>>
{
    public async Task<List<DoctorApplicationDto>> Handle(GetDoctorApplicationsQuery request, CancellationToken cancellationToken)
    {
        var applications = await repository.GetAll();

        return mapper.Map<List<DoctorApplicationDto>>(applications);
    }
}