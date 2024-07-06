namespace MediToring.Application.Features.Medications.Commands.CreateMedication;

public class CraeteMedicationCommand : IRequest<Guid>
{
    public required string Name { get; set; }
    public required string Dosage { get; set; }
    public required string Instruction { get; set; }
}