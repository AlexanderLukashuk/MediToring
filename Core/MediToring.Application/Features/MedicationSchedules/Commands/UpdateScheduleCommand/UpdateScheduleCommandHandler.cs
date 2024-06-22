namespace MediToring.Application.Features.MedicationSchedules.Commands.UpdateScheduleCommand;

public class UpdateScheduleCommandHandler(IMedicationScheduleRepository repository)
    : IRequestHandler<UpdateScheduleCommand>
{
    public async Task Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
    {
        var startDateUtc = DateTime.SpecifyKind(request.StartTime, DateTimeKind.Utc);
        var endDateUtc = DateTime.SpecifyKind(request.EndTime, DateTimeKind.Utc);

        var schedule = await repository.Get(request.Id);

        if (schedule == null)
        {
            throw new NotFoundException(nameof(MedicationSchedule), request.Id);
        }

        schedule.MedicationId = request.MedicationId;
        schedule.UserId = request.UserId;
        schedule.StartTime = startDateUtc;
        schedule.EndTime = endDateUtc;
        schedule.DailyDoses = request.DailyDoses.Select(d => 
            new DailyDose { TimeOfDay = d.TimeOfDay, BeforeMeal = d.BeforeMeal }).ToList();

        repository.Update(schedule);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);
    }
}