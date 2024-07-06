namespace MediToring.Domain.Models;

public class DailyDoseRecord
{
    public Guid Id { get; set; }
    public Guid MedicationScheduleId { get; set; }
    public MedicationSchedule MedicationSchedule { get; set; }
    public DateTime Date { get; set; }
    public bool IsTaken { get; set; }
}