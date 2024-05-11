using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.MedicationSchedules.Commands.DeleteScheduleCommand;

public class DeleteScheduleCommandHandler(IMediToringDbContext context) : IRequestHandler<DeleteScheduleCommand>
{
    public async Task Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        // if delete schedule will crash then add "new object[] { request.Id } instead of request.Id"
        var schedule = await context.MedicationSchedules.FindAsync(request.Id, cancellationToken);

        if (schedule == null)
        {
            throw new NotFoundException(nameof(MedicationSchedule), request.Id);
        }

        context.MedicationSchedules.Remove(schedule);
        await context.SaveChangesAsync(cancellationToken);
    }
}