namespace MediToring.Application.Features.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
{
    public GetUserDetailsQueryValidator()
    {
        RuleFor(user => user.Id).NotEqual(Guid.Empty);
    }
}