namespace MediToring.Domain.Models;

public class DoctorApplication : EntityBase<Guid>, IAggregateRoot
{
    public string? UserId { get; set; }
    public string? Specialization { get; set; }
    public string? Qualification { get; set; }
    public int ExperienceYears { get; set; }
    public string? Clinic { get; set; }
    public string? Bio { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime SubmittedAt { get; set; }

    public DoctorApplication() { }

    public DoctorApplication(string userId, string specialization, string qualification, int experience, string clinic, string bio)
    {
        UserId = userId;
        Specialization = specialization;
        Qualification = qualification;
        ExperienceYears = experience;
        Clinic = clinic;
        Bio = bio;
        Status = ApplicationStatus.Pending;
        SubmittedAt = DateTime.UtcNow;
    }
}