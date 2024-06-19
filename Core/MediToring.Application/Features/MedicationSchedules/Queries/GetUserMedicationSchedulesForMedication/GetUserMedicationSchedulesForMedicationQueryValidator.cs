namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedulesForMedication;

public class GetUserMedicationSchedulesForMedicationQueryValidator : AbstractValidator<GetUserMedicationSchedulesForMedicationQuery>
{
    public GetUserMedicationSchedulesForMedicationQueryValidator()
    {
        RuleFor(schedule =>
            schedule.UserId).NotEqual(Guid.Empty);
        RuleFor(schedule =>
            schedule.MedicationId).NotEqual(Guid.Empty);
    }
}