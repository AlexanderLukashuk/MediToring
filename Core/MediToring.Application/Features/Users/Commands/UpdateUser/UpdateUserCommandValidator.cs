namespace MediToring.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(updateUserCommand => updateUserCommand.Id).NotEqual(Guid.Empty);
        RuleFor(updateUserCommand => updateUserCommand.PasswordHash).NotEmpty().MinimumLength(8);
        RuleFor(updateUserCommand => updateUserCommand.Name).NotEmpty().MaximumLength(100);
    }
}