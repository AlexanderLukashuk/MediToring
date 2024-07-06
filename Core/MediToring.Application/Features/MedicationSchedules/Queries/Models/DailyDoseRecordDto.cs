namespace MediToring.Application.Features.MedicationSchedules.Queries.Models;

public class DailyDoseRecordDto
{
    public DateTime Date { get; set; }
    public bool IsTaken { get; set; }
}