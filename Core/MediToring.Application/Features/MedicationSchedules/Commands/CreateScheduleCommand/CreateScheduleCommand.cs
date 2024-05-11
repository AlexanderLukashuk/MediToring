using MediatR;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.MedicationSchedules.Commands.CreateScheduleCommand;

public class CreateScheduleCommand : IRequest<Guid>
{
    public Guid MedicationId { get; set; }
    public Guid UserId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ICollection<DailyDose> DailyDoses { get; set; }
}