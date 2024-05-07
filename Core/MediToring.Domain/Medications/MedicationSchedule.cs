using BuildingBlocks.Domain;
using MediToring.Domain.Users;

namespace MediToring.Domain.Medications;

public class MedicationSchedule : EntityBase<Guid>
{
    public Guid MedicationId { get; set; }
    public Medication Medication { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<DailyDose> DailyDoses { get; set; }
    public bool IsTaken { get; set; }
}