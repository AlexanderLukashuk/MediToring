namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQueryHandler(IMedicationScheduleRepository repository)
    : IRequestHandler<GetUserMedicationSchedulesForMedicationQuery, MedicationScheduleVm>
{
    public async Task<MedicationScheduleVm> Handle(GetUserMedicationSchedulesForMedicationQuery request, CancellationToken cancellationToken)
    {
        var schedules = await repository.GetByUserIdAndMedicationId(request.UserId, request.MedicationId);

        var scheduleDtos = schedules.Select(schedule => new MedicationScheduleDto
        {
            Id = schedule.Id,
            MedicationName = schedule.Medication.Name,
            StartTime = schedule.StartTime,
            EndTime = schedule.EndTime,
            IsTaken = schedule.IsTaken
        }).ToList();

        return new MedicationScheduleVm { Schedules = scheduleDtos };
    }
}