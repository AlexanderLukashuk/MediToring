
using MediToring.Domain.Models;

namespace MediToring.Application.Features.Profiles.Commands.CreateProfile;

public class CreateProfileCommandHandler(IProfileRepository repository) : IRequestHandler<CreateProfileCommand, Guid>
{
    public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var birthDate = DateTimeConverter.ConvertToUtc(request.DateOfBirth);

        var profile = new UserProfile(request.UserId, request.FirstName, request.LastName, birthDate, request.Height, request.Weight);

        repository.Add(profile);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);

        return profile.Id;
    }
}