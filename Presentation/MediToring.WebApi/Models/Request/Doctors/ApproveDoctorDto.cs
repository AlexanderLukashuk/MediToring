namespace MediToring.WebApi.Models.Request.Doctors;

public class ApproveDoctorDto
{
    public string? UserId { get; set; }
    public Guid UserProfileId { get; set; }
    public string? Specialization { get; set; }
    public string? Qualification { get; set; }
    public int ExperienceYears { get; set; }
    public string? Clinic { get; set; }
    public string? Bio { get; set; }
}