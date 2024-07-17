
namespace MediToring.Infrastructure.Repositories;

public class DoctorApplicationRepository(MediToringDbContext context) : IDoctorApplicationRepository
{
    public IUnitOfWork UnitOfWork => context;

    public DoctorApplication Add(DoctorApplication application)
    {
        return context.DoctorApplications.Add(application).Entity;
    }
}