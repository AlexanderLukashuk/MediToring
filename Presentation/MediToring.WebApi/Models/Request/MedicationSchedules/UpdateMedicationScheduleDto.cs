using MediToring.Application.Features.MedicationSchedules.Commands.Models;

namespace MediToring.WebApi.Models.Request.MedicationSchedules;

public class UpdateMedicationScheduleDto
{
    public Guid Id { get; set; }
    public Guid MedicationId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<DailyDoseDto> DailyDoses { get; set; }
}