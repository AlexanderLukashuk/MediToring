using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(IMediToringDbContext context) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user =>
            user.Id == request.Id, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        user.Name = request.Name;
        // СДЕЛАТЬ МЕТОД ChangePassword
        // user.PasswordHash = request.PasswordHash;

        await context.SaveChangesAsync(cancellationToken);
    }
}