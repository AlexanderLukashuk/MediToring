using MediatR;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.MedicationSchedules.Commands.CreateScheduleCommand;

public class CreateScheduleCommandHandler(IMediToringDbContext context) 
    : IRequestHandler<CreateScheduleCommand, Guid>
{
    public async Task<Guid> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = new MedicationSchedule(
            request.MedicationId, 
            request.UserId, 
            request.StartTime, 
            request.EndTime, 
            request.DailyDoses
        );

        await context.MedicationSchedules.AddAsync(schedule);
        await context.SaveChangesAsync(cancellationToken);

        return schedule.Id;
    }
}