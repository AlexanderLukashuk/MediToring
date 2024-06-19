namespace MediToring.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IMediToringDbContext context) : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Email, request.PasswordHash)
        {
            Name = request.Name
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}