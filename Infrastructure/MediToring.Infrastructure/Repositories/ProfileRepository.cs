
namespace MediToring.Infrastructure.Repositories;

public class ProfileRepository(MediToringDbContext context) : IProfileRepository
{
    public IUnitOfWork UnitOfWork => context;

    public UserProfile Add(UserProfile profile)
    {
        return context.UserProfiles.Add(profile).Entity;
    }

    public async Task<UserProfile?> Get(Guid guid)
    {
        var profile = await context.UserProfiles.FindAsync(guid);

        return profile;
    }

    public void Update(UserProfile profile)
    {
        context.Entry(profile).State = EntityState.Modified;
    }

    public async Task<UserProfile?> GetByUserId(string userId)
    {
        return await context.UserProfiles
            .FirstOrDefaultAsync(profile => profile.UserId == userId);
    }

    public async Task<List<UserProfile>> GetAllDoctors(CancellationToken cancellationToken)
    {
        var doctorRoleId = await context.Roles
            .Where(r => r.Name == "Doctor")
            .Select(r => r.Id)
            .FirstOrDefaultAsync(cancellationToken);

        var doctorUserIds = await context.UserRoles
            .Where(ur => ur.RoleId == doctorRoleId)
            .Select(ur => ur.UserId)
            .ToListAsync(cancellationToken);

        var doctors = await context.UserProfiles
            .Where(up => doctorUserIds.Contains(up.UserId))
            .ToListAsync(cancellationToken);

        return doctors;
    }
}