namespace MediToring.Application.Features.MedicationSchedules.Commands.CreateScheduleCommand;

public class CreateScheduleCommand : IRequest<Guid>
{
    public Guid MedicationId { get; set; }
    public required string UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public required ICollection<DailyDoseDto> DailyDoses { get; set; }
}