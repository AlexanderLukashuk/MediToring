namespace MediToring.Application.Features.MedicationSchedules.Commands.CreateScheduleCommand;

public class CreateScheduleCommandHandler(IMedicationScheduleRepository repository) 
    : IRequestHandler<CreateScheduleCommand, Guid>
{
    public async Task<Guid> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var (startTimeUtc, endTimeUtc) = DateTimeConverter.ConvertToUtc(request.StartTime, request.EndTime);

        var dailyDoses = request.DailyDoses.Select(d => 
            new DailyDose { TimeOfDay = d.TimeOfDay, BeforeMeal = d.BeforeMeal }).ToList();

        var schedule = new MedicationSchedule(
            request.MedicationId, 
            request.UserId, 
            startTimeUtc, 
            endTimeUtc, 
            dailyDoses
        );

        repository.Add(schedule);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);

        return schedule.Id;
    }
}