using Microsoft.AspNetCore.Identity;

namespace MediToring.Domain.Medications;

public class MedicationSchedule : EntityBase<Guid>, IAggregateRoot
{
    public Guid MedicationId { get; set; }
    public Medication Medication { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<DailyDose> DailyDoses { get; set; }
    public bool IsTaken { get; set; }

    private MedicationSchedule() { }

    public MedicationSchedule(Guid medicationId, string userId, DateTime startTime, DateTime endTime, ICollection<DailyDose> dailyDoses)
        : this(Guid.NewGuid(), medicationId, userId, startTime, endTime, dailyDoses) { }

    public MedicationSchedule(Guid guid, Guid medicationId, string userId, DateTime startTime, DateTime endTime, ICollection<DailyDose> dailyDoses)
    {
        Id = guid;
        MedicationId = medicationId;
        UserId = userId;
        StartTime = startTime;
        EndTime = endTime;
        DailyDoses = dailyDoses;
    }
}