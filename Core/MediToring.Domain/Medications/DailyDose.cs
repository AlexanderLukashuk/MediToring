namespace MediToring.Domain.Medications;

public class DailyDose
{
    public TimeOfDay TimeOfDay { get; set; }
    public bool BeforeMeal { get; set; }
}