using MediToring.Domain.Models;
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
    public ICollection<DailyDoseRecord> DoseRecords { get; set; }

    private MedicationSchedule()
    {
        DailyDoses = new List<DailyDose>();
        DoseRecords = new List<DailyDoseRecord>();
    }

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
        DoseRecords = GenerateDoseRecords(startTime, endTime);
    }

    private ICollection<DailyDoseRecord> GenerateDoseRecords(DateTime startTime, DateTime endTime)
    {
        var records = new List<DailyDoseRecord>();
        for (var date = startTime.Date; date <= endTime.Date; date = date.AddDays(1))
        {
            records.Add(new DailyDoseRecord { Id = Guid.NewGuid(), Date = date, IsTaken = false });
        }
        return records;
    }
}