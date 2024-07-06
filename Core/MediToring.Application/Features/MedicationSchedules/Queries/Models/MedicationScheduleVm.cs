namespace MediToring.Application.Features.MedicationSchedules.Queries.Models;

public class MedicationScheduleVm
{
    public required IList<MedicationScheduleDto> Schedules { get; set; }
}