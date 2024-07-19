


namespace MediToring.Infrastructure.Repositories;

public class DoctorApplicationRepository(MediToringDbContext context) : IDoctorApplicationRepository
{
    public IUnitOfWork UnitOfWork => context;

    public DoctorApplication Add(DoctorApplication application)
    {
        return context.DoctorApplications.Add(application).Entity;
    }

    public async Task<DoctorApplication?> Get(Guid id)
    {
        return await context.DoctorApplications.FindAsync(id);
    }

    public async Task<List<DoctorApplication>> GetAll()
    {
        return await context.DoctorApplications.ToListAsync();
    }

    public async Task Remove(DoctorApplication application)
    {
        context.DoctorApplications.Remove(application);
        await context.SaveChangesAsync();
    }
}