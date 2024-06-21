namespace MediToring.Domain;

public interface IMedicationScheduleRepository : IRepository<MedicationSchedule>
{
    MedicationSchedule Add(MedicationSchedule schedule);
    Task<MedicationSchedule> Get(Guid id);
    void Delete(MedicationSchedule schedule);
    void Update(MedicationSchedule schedule);
    Task<IEnumerable<MedicationSchedule>> GetAll();
    Task<IEnumerable<MedicationSchedule>> GetByUserId(string userId);
    Task<IEnumerable<MedicationSchedule>> GetByUserIdAndMedicationId(string userId, Guid medicationId);
}
