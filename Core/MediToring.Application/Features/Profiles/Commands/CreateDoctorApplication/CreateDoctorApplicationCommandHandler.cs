
using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Commands.CreateDoctorApplication;

public class CreateDoctorApplicationCommandHandler(IDoctorApplicationRepository repository) 
    : IRequestHandler<CreateDoctorApplicationCommand, Guid>
{
    public async Task<Guid> Handle(CreateDoctorApplicationCommand request, CancellationToken cancellationToken)
    {
        var application = new DoctorApplication
        {
            UserId = request.UserId,
            Specialization = request.Specialization,
            Qualification = request.Qualification,
            ExperienceYears = request.ExperienceYears,
            Clinic = request.Clinic,
            Bio = request.Bio,
            Status = ApplicationStatus.Pending,
            SubmittedAt = DateTime.UtcNow
        };

        repository.Add(application);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);

        return application.Id;
    }
}