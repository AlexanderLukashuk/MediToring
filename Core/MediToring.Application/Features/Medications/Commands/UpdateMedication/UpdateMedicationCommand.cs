namespace MediToring.Application.Features.Medications.Commands.UpdateMedication;

public class UpdateMedicationCommand : IRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Dosage { get; set; }
    public required string Instruction { get; set; }
}