namespace MediToring.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? PasswordHash { get; set; }
}