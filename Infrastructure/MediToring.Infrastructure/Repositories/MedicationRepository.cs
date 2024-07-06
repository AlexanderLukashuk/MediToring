namespace MediToring.Infrastructure.Repositories;

public class MedicationRepository(MediToringDbContext context) : IMedicationRepository
{
    public IUnitOfWork UnitOfWork => context;

    public Medication Add(Medication medication)
    {
        return context.Medications.Add(medication).Entity;
    }

    public void Delete(Medication medication)
    {
        context.Medications.Remove(medication);
    }

    public async Task<Medication?> Get(Guid guid)
    {
        var medication = await context.Medications.FindAsync(guid);

        return medication;
    }

    public async Task<IEnumerable<Medication>> GetAll()
    {
        return await context.Medications.ToListAsync();
    }

    public void Update(Medication medication)
    {
        context.Entry(medication).State = EntityState.Modified;
    }
}
