using MediatR;

namespace MediToring.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<Guid>
{
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? Name { get; set; }
}