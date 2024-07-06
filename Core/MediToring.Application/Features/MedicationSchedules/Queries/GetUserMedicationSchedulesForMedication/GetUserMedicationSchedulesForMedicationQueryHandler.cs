namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQueryHandler(IMedicationScheduleRepository repository)
    : IRequestHandler<GetUserMedicationSchedulesForMedicationQuery, MedicationScheduleVm>
{
    public async Task<MedicationScheduleVm> Handle(GetUserMedicationSchedulesForMedicationQuery request, CancellationToken cancellationToken)
    {
        // var schedule = await repository.GetByUserIdAndMedicationId(request.UserId, request.MedicationId);
        var schedule = await repository.GetByIdAndUserId(request.ScheduleId, request.UserId);

        if (schedule == null)
        {
            return new MedicationScheduleVm { Schedules = new List<MedicationScheduleDto>() };
        }

        // var scheduleDtos = schedules.Select(schedule => new MedicationScheduleDto
        var scheduleDto = new MedicationScheduleDto
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
        // }).ToList();
        };

        // return new MedicationScheduleVm { Schedules = scheduleDtos };
        return new MedicationScheduleVm { Schedules = new List<MedicationScheduleDto> { scheduleDto } };
    }
}