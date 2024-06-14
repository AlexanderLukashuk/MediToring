using BuildingBlocks.Infrastructure;
using MediToring.Domain.Medications;

namespace MediToring.Domain;

public interface IMedicationScheduleRepository : IRepository<MedicationSchedule>
{
    MedicationSchedule Add(MedicationSchedule schedule);
    Task<MedicationSchedule> Get(Guid id);
    void Delete(MedicationSchedule schedule);
    void Update(MedicationSchedule schedule);
}
