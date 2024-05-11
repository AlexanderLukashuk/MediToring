using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.MedicationSchedules.Commands.UpdateScheduleCommand;

public class UpdateScheduleCommandHandler(IMediToringDbContext context)
    : IRequestHandler<UpdateScheduleCommand>
{
    public async Task Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await context.MedicationSchedules.FirstOrDefaultAsync(schedule =>
            schedule.Id == request.Id, cancellationToken);

        if (schedule == null)
        {
            throw new NotFoundException(nameof(MedicationSchedule), request.Id);
        }

        schedule.MedicationId = request.MedicationId;
        schedule.UserId = request.UserId;
        schedule.StartTime = request.StartTime;
        schedule.EndTime = request.EndTime;
        schedule.DailyDoses = request.DailyDoses;

        await context.SaveChangesAsync(cancellationToken);
    }
}