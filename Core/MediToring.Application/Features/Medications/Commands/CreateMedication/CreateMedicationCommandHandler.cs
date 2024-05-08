using MediatR;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.Medications.Commands.CreateMedication;

public class CreateMedicationCommandHandler(IMediToringDbContext context) 
    : IRequestHandler<CraeteMedicationCommand, Guid>
{
    public async Task<Guid> Handle(CraeteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = new Medication(request.Name, request.Dosage, request.Instruction);

        await context.Medications.AddAsync(medication);
        await context.SaveChangesAsync(cancellationToken);

        return medication.Id;
    }
}