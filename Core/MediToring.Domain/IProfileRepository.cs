using MediToring.Domain.Models;

namespace MediToring.Domain;

public interface IProfileRepository : IRepository<UserProfile>
{
    UserProfile Add(UserProfile profile);
    Task<UserProfile?> Get(Guid guid);
    void Update(UserProfile profile);
}