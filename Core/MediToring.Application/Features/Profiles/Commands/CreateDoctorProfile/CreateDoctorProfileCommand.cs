namespace MediToring.Application.Features.Profiles.Commands.CreateDoctorProfile;

public class CreateDoctorProfileCommand : IRequest<Guid>
{
    public Guid UserProfileId { get; set; }
    public string? Specialization { get; set; }
    public string? Qualification { get; set; }
    public int ExperienceYears { get; set; }
    public string? Clinic { get; set; }
    public string? Bio { get; set; }
}