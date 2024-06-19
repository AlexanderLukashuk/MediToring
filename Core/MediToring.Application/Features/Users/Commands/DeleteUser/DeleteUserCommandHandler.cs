namespace MediToring.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(IMediToringDbContext context) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}