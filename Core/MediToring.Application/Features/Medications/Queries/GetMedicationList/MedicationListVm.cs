namespace MediToring.Application.Features.Medications.Queries.GetMedicationList;

public class MedicationListVm
{
    public required IList<MedicationLookupDto> Medications { get; set; }
}