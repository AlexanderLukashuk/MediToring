using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Queries.Models;

public class DoctorApplicationDto : IMapWith<DoctorApplication>
{
    public string? UserId { get; set; }
    public string? Specialization { get; set; }
    public string? Qualification { get; set; }
    public int ExperienceYears { get; set; }
    public string? Clinic { get; set; }
    public string? Bio { get; set; }
    public ApplicationStatus Status { get; set; }
    public DateTime SubmittedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DoctorApplication, DoctorApplicationDto>();
    }
}