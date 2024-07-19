
using MediToring.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace MediToring.Application.Features.Profiles.Commands.ApproveDoctor;

public class ApproveDoctorCommandHandler(
    IDoctorApplicationRepository applicationRepository, 
    IDoctorProfileRepository doctorRepository, 
    IProfileRepository profileRepository,
    UserManager<IdentityUser> userManager, 
    RoleManager<IdentityRole> roleManager) 
    : IRequestHandler<ApproveDoctorCommand>
{
    public async Task Handle(ApproveDoctorCommand request, CancellationToken cancellationToken)
    {
        var application = await applicationRepository.Get(request.ApplicationId);
        if (application == null)
        {
            throw new NotFoundException("DoctorApplication", request.ApplicationId);
        }

        var user = await userManager.FindByIdAsync(application.UserId);
        if (user == null)
        {
            throw new NotFoundException("User", application.UserId);
        }

        if (!await roleManager.RoleExistsAsync("Doctor"))
        {
            await roleManager.CreateAsync(new IdentityRole("Doctor"));
        }

        await userManager.AddToRoleAsync(user, "Doctor");

        var userProfile = await profileRepository.GetByUserId(application.UserId);
        if (userProfile == null)
        {
            throw new NotFoundException("Profile", user.Id);
        }

        var doctorProfile = new DoctorProfile(
            userProfile.Id,
            application.Specialization,
            application.Qualification,
            application.ExperienceYears,
            application.Clinic,
            application.Bio
        );

        doctorRepository.Add(doctorProfile);
        await applicationRepository.Remove(application);
    }
}