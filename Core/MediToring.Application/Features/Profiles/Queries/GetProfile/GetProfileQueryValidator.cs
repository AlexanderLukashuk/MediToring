namespace MediToring.Application.Features.Profiles.Queries.GetProfile;

public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
{
    public GetProfileQueryValidator()
    {
        RuleFor(profile => profile.UserId).NotEmpty();
    }
}