namespace MediToring.Application.Features.Profiles.Commands.CreateProfile;

public class CreateProfileCommandValidator : AbstractValidator<CreateProfileCommand>
{
    public CreateProfileCommandValidator()
    {
        RuleFor(profile => profile.FirstName).NotEmpty().MaximumLength(60);
        RuleFor(profile => profile.LastName).NotEmpty().MaximumLength(60);
        RuleFor(profile => profile.DateOfBirth).NotEmpty();
    }
}