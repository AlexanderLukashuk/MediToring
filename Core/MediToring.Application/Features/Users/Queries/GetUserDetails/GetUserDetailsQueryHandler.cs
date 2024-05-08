using AutoMapper;
using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler(IMediToringDbContext context, IMapper mapper) 
    : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
{
    public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(user =>
            user.Id == request.Id, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return mapper.Map<UserDetailsVm>(user);
    }
}