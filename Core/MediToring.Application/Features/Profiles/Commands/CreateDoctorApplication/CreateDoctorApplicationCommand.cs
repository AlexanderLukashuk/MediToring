namespace MediToring.Application.Features.Profiles.Commands.CreateDoctorApplication;

public class CreateDoctorApplicationCommand : IRequest<Guid>
{
    public string? UserId { get; set; }
    public string? Specialization { get; set; }
    public string? Qualification { get; set; }
    public int ExperienceYears { get; set; }
    public string? Clinic { get; set; }
    public string? Bio { get; set; }
}