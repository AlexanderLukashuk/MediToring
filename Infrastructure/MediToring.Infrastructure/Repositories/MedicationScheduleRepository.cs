using System.Xml.Serialization;
using BuildingBlocks.Application;
using MediToring.Domain;
using MediToring.Domain.Medications;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Infrastructure.Repositories;

public class MedicationScheduleRepository : IMedicationScheduleRepository
{
    private readonly MediToringDbContext _context;

    public MedicationScheduleRepository(MediToringDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public MedicationSchedule Add(MedicationSchedule schedule)
    {
        return _context.MedicationSchedules.Add(schedule).Entity;
    }

    public void Delete(MedicationSchedule schedule)
    {
        _context.MedicationSchedules.Remove(schedule);
    }

    public async Task<MedicationSchedule> Get(Guid id)
    {
        return await _context.MedicationSchedules.FindAsync(id);
    }

    public async Task<IEnumerable<MedicationSchedule>> GetAll()
    {
        return await _context.MedicationSchedules
            .Include(ms => ms.DailyDoses)
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicationSchedule>> GetByUserId(Guid userId)
    {
        return await _context.MedicationSchedules
            .Where(schedule => schedule.UserId == userId)
            .Include(schedule => schedule.Medication)
            .ToListAsync();
    }

    public async Task<IEnumerable<MedicationSchedule>> GetByUserIdAndMedicationId(Guid userId, Guid medicationId)
    {
        return await _context.MedicationSchedules
            .Where(schedule => schedule.UserId == userId && schedule.MedicationId == medicationId)
            .Include(schedule => schedule.Medication)
            .ToListAsync();
    }

    public void Update(MedicationSchedule schedule)
    {
        _context.Entry(schedule).State = EntityState.Modified;
    }
}
