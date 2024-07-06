namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQueryValidator : AbstractValidator<GetUserMedicationSchedulesForMedicationQuery>
{
    public GetUserMedicationSchedulesForMedicationQueryValidator()
    {
        RuleFor(schedule =>
            schedule.UserId).NotEmpty();
        RuleFor(schedule =>
            schedule.ScheduleId).NotEqual(Guid.Empty);
    }
}