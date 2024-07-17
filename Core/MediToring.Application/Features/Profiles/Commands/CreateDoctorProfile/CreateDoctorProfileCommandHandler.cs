
using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Commands.CreateDoctorProfile;

public class CreateDoctorProfileCommandHandler(IDoctorProfileRepository repository) : IRequestHandler<CreateDoctorProfileCommand, Guid>
{
    public async Task<Guid> Handle(CreateDoctorProfileCommand request, CancellationToken cancellationToken)
    {
        var doctorProfile = new DoctorProfile
        {
            UserProfileId = request.UserProfileId,
            Specialization = request.Specialization,
            Qualification = request.Qualification,
            ExperienceYears = request.ExperienceYears,
            Clinic = request.Clinic,
            Bio = request.Bio
        };

        repository.Add(doctorProfile);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);

        return doctorProfile.Id;
    }
}