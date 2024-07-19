namespace MediToring.Domain.Models;

public class DoctorProfile : EntityBase<Guid>, IAggregateRoot
{
    public Guid UserProfileId { get; set; }
    public UserProfile UserProfile { get; set; }
    public string? Specialization { get; set; }
    public string? Qualification { get; set; }
    public int ExperienceYears { get; set; }
    public string? Clinic { get; set; }
    public string? Bio { get; set; }
    public List<string> Reviews { get; set; }
    public List<int> Rating { get; set; }

    public DoctorProfile()
    {
        Reviews = new List<string>();
        Rating = new List<int>();
    }

    public DoctorProfile(Guid userProfileId, string specialization, string qualification, int experience, string clinic, string bio)
    {
        UserProfileId = userProfileId;
        Specialization = specialization;
        Qualification = qualification;
        ExperienceYears = experience;
        Clinic = clinic;
        Bio = bio;
        Reviews = new List<string>();
        Rating = new List<int>();
    }
}