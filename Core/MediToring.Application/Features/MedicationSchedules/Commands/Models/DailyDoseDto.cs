namespace MediToring.Application.Features.MedicationSchedules.Commands.Models;

public class DailyDoseDto
{
    public TimeOfDay TimeOfDay { get; set; }
    public bool BeforeMeal { get; set; }
}