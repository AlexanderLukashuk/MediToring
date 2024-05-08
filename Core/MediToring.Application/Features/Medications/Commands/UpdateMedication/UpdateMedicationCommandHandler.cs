using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.Medications.Commands.UpdateMedication;

public class UpdateMedicationCommandHandler(IMediToringDbContext context) 
    : IRequestHandler<UpdateMedicationCommand>
{
    public async Task Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await context.Medications.FirstOrDefaultAsync(medication =>
            medication.Id == request.Id, cancellationToken);

        if (medication == null)
        {
            throw new NotFoundException(nameof(Medication), request.Id);
        }

        medication.Name = request.Name;
        medication.Dosage = request.Dosage;
        medication.Instruction = request.Instruction;

        await context.SaveChangesAsync(cancellationToken);
    }
}