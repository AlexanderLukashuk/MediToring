
using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Commands.UpdateProfile;

public class UpdateProfileCommandHandler(IProfileRepository repository) : IRequestHandler<UpdateProfileCommand>
{
    public async Task Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var birthDate = DateTimeConverter.ConvertToUtc(request.DateOfBirth);

        var profile = await repository.Get(request.Id);

        if (profile == null)
        {
            throw new NotFoundException(nameof(UserProfile), request.Id);
        }

        if (profile.UserId != request.UserId)
        {
            throw new ForbiddenException("You can't update another user's profile");
        }

        profile.FirstName = request.FirstName;
        profile.LastName = request.LastName;
        profile.DateOfBirth = birthDate;
        profile.Height = request.Height;
        profile.Weight = request.Weight;

        repository.Update(profile);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);
    }
}