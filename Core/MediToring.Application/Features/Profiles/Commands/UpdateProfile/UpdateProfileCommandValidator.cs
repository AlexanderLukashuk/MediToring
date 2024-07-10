namespace MediToring.Application.Features.Profiles.Commands.UpdateProfile;

public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
    public UpdateProfileCommandValidator()
    {
        RuleFor(profile => profile.Id).NotEqual(Guid.Empty);
        RuleFor(profile => profile.FirstName).NotEmpty();
        RuleFor(profile => profile.LastName).NotEmpty();
        RuleFor(profile => profile.DateOfBirth).NotEmpty();
    }
}