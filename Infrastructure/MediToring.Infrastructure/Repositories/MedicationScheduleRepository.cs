using System.Xml.Serialization;

namespace MediToring.Infrastructure.Repositories;

public class MedicationScheduleRepository(MediToringDbContext context) : IMedicationScheduleRepository
{
    public IUnitOfWork UnitOfWork => context;

    public MedicationSchedule Add(MedicationSchedule schedule)
    {
        return context.MedicationSchedules.Add(schedule).Entity;
    }

    public void Delete(MedicationSchedule schedule)
    {
        context.MedicationSchedules.Remove(schedule);
    }

    public async Task<MedicationSchedule?> Get(Guid id)
    {
        return await context.MedicationSchedules.FindAsync(id);
    }

    public async Task<IEnumerable<MedicationSchedule>> GetAll()
    {
        return await context.MedicationSchedules
            .Include(ms => ms.DailyDoses)
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicationSchedule>> GetByUserId(string userId)
    {
        return await context.MedicationSchedules
            .Include(schedule => schedule.Medication)
            .Include(schedule => schedule.DoseRecords)
            .Where(schedule => schedule.UserId == userId)
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicationSchedule>> GetByUserIdAndMedicationId(string userId, Guid medicationId)
    {
        return await context.MedicationSchedules
            .Include(schedule => schedule.Medication)
            .Include(schedule => schedule.DoseRecords)
            .Where(schedule => schedule.UserId == userId && schedule.MedicationId == medicationId)
            .ToListAsync();
    }

    public async Task<MedicationSchedule?> GetByIdAndUserId(Guid id, string userId)
    {
        return await context.MedicationSchedules
            .Include(schedule => schedule.Medication)
            .Include(schedule => schedule.DoseRecords)
            .FirstOrDefaultAsync(schedule => schedule.Id == id && schedule.UserId == userId);
    }

    public void Update(MedicationSchedule schedule)
    {
        context.Entry(schedule).State = EntityState.Modified;
    }
}
