using MediatR;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.MedicationSchedules.Commands.UpdateScheduleCommand;

public class UpdateScheduleCommand : IRequest
{
    public Guid Id { get; set; }
    public Guid MedicationId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<DailyDose> DailyDoses { get; set; }
}