namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;

public class GetUserMedicationSchedulesQueryHandler(IMedicationScheduleRepository repository)
    : IRequestHandler<GetUserMedicationSchedulesQuery, MedicationScheduleVm>
{
    public async Task<MedicationScheduleVm> Handle(GetUserMedicationSchedulesQuery request, CancellationToken cancellationToken)
    {
        var schedules = await repository.GetByUserId(request.UserId);

        var scheduleDtos = schedules.Select(schedule => new MedicationScheduleDto
        {
            Id = schedule.Id,
            MedicationName = schedule.Medication.Name,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            DoseRecords = schedule.DoseRecords.Select(record => new DailyDoseRecordDto
            {
                Date = record.Date,
                IsTaken = record.IsTaken
            }).ToList()
        }).ToList();

        return new MedicationScheduleVm { Schedules = scheduleDtos };
    }
}