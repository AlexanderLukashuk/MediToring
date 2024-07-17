
namespace MediToring.Infrastructure.Repositories;

public class DoctorProfileRepository(MediToringDbContext context) : IDoctorProfileRepository
{
    public IUnitOfWork UnitOfWork => context;

    public DoctorProfile Add(DoctorProfile profile)
    {
        return context.DoctorProfiles.Add(profile).Entity;
    }
}