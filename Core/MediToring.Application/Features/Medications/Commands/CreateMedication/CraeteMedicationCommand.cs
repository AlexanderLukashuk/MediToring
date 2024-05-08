using MediatR;

namespace MediToring.Application.Features.Medications.Commands.CreateMedication;

public class CraeteMedicationCommand : IRequest<Guid>
{
    public string? Name { get; set; }
    public string? Dosage { get; set; }
    public string? Instruction { get; set; }
}