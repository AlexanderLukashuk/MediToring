

namespace MediToring.Infrastructure.Repositories;

public class DoctorProfileRepository(MediToringDbContext context) : IDoctorProfileRepository
{
    public IUnitOfWork UnitOfWork => context;

    public DoctorProfile Add(DoctorProfile profile)
    {
        return context.DoctorProfiles.Add(profile).Entity;
    }

    public async Task<DoctorProfile?> Get(Guid id)
    {
        return await context.DoctorProfiles.FindAsync(id);
    }

    public async Task<List<DoctorProfile>> GetAll()
    {
        return await context.DoctorProfiles.ToListAsync();
    }

    public async Task Remove(DoctorProfile profile)
    {
        context.DoctorProfiles.Remove(profile);
        await context.SaveChangesAsync();
    }
}