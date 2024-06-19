namespace MediToring.Application.Features.Medications.Queries.GetMedicationDetails;

public class GetMedicationDetailsQueryValidator : AbstractValidator<GetMedicationDetailsQuery>
{
    public GetMedicationDetailsQueryValidator()
    {
        RuleFor(medication => medication.Id).NotEqual(Guid.Empty);
    }
}