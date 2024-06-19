namespace MediToring.Application.Features.Medications.Commands.UpdateMedication;

public class UpdateMedicationCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Dosage { get; set; }
    public string? Instruction { get; set; }
}