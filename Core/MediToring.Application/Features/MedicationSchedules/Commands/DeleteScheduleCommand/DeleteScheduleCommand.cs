using MediatR;

namespace MediToring.Application.Features.MedicationSchedules.Commands.DeleteScheduleCommand;

public class DeleteScheduleCommand : IRequest
{
    public Guid Id { get; set; }
}