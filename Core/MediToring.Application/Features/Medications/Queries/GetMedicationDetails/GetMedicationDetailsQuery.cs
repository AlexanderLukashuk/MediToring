namespace MediToring.Application.Features.Medications.Queries.GetMedicationDetails;

public class GetMedicationDetailsQuery : IRequest<MedicationDetailsVm>
{
    public Guid Id { get; set;}
}