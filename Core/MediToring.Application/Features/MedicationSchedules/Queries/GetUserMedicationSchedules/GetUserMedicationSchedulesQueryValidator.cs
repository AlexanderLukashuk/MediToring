namespace MediToring.Application.Features.MedicationSchedules.Queries.GetUserMedicationSchedules;

public class GetUserMedicationSchedulesQueryValidator : AbstractValidator<GetUserMedicationSchedulesQuery>
{
    public GetUserMedicationSchedulesQueryValidator()
    {
        RuleFor(query => 
            query.UserId).NotEqual(Guid.Empty);
    }
}