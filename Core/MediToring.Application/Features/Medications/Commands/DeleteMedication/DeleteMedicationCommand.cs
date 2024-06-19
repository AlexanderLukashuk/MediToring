namespace MediToring.Application.Features.Medications.Commands.DeleteMedication;

public class DeleteMedicationCommand : IRequest
{
    public Guid Id { get; set; }
}