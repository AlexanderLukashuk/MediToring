namespace MediToring.Application.Features.Profiles.Commands.ApproveDoctor;

public class ApproveDoctorCommand : IRequest
{
    public Guid ApplicationId { get; set; }
}