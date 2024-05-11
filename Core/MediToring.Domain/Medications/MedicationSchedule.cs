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

    private MedicationSchedule() { }

    public MedicationSchedule(Guid medicationId, Guid userId, DateTime startTime, DateTime endTime, ICollection<DailyDose> dailyDoses)
        : this(Guid.NewGuid(), medicationId, userId, startTime, endTime, dailyDoses) { }

    public MedicationSchedule(Guid guid, Guid medicationId, Guid userId, DateTime startTime, DateTime endTime, ICollection<DailyDose> dailyDoses)
    {
        Id = guid;
        MedicationId = medicationId;
        UserId = userId;
        StartTime = startTime;
        EndTime = endTime;
        DailyDoses = dailyDoses;
    }
}