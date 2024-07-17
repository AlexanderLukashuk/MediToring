using MediToring.Domain.Models;

namespace MediToring.Domain;

public interface IProfileRepository : IRepository<UserProfile>
{
    UserProfile Add(UserProfile profile);
    Task<UserProfile?> Get(Guid guid);
    void Update(UserProfile profile);
    Task<UserProfile?> GetByUserId(string userId);
    Task<List<UserProfile>> GetAllDoctors(CancellationToken cancellationToken);
}