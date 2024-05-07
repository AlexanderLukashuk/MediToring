using FluentValidation;

namespace MediToring.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(createUserCommand =>
            createUserCommand.Email).NotEmpty().EmailAddress();
        RuleFor(createUserCommand =>
            createUserCommand.PasswordHash).NotEmpty().MinimumLength(8);
        RuleFor(createUserCommand =>
            createUserCommand.Name).NotEmpty().MaximumLength(100);
    }
}