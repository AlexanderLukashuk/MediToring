using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.Medications.Commands.DeleteMedication;

public class DeleteMedicationCommandHandler(IMediToringDbContext context) 
    : IRequestHandler<DeleteMedicationCommand>
{
    public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await context.Medications.
            FindAsync(new object[] { request.Id }, cancellationToken);

        if (medication == null)
        {
            throw new NotFoundException(nameof(Medication), request.Id);
        }

        context.Medications.Remove(medication);
        await context.SaveChangesAsync(cancellationToken);
    }
}