using MediatR;
using MediToring.Application.Common.Exceptions;
using MediToring.Application.Interfaces;
using MediToring.Domain;
using MediToring.Domain.Medications;

namespace MediToring.Application.Features.Medications.Commands.DeleteMedication;

public class DeleteMedicationCommandHandler(IMedicationRepository repository) 
    : IRequestHandler<DeleteMedicationCommand>
{
    public async Task Handle(DeleteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await repository.Get(request.Id);

        if (medication == null)
        {
            throw new NotFoundException(nameof(Medication), request.Id);
        }

        repository.Delete(medication);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);
    }
}