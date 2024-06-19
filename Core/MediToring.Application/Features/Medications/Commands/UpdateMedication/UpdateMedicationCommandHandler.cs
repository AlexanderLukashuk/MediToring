namespace MediToring.Application.Features.Medications.Commands.UpdateMedication;

public class UpdateMedicationCommandHandler(IMedicationRepository repository) 
    : IRequestHandler<UpdateMedicationCommand>
{
    public async Task Handle(UpdateMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await repository.Get(request.Id);

        if (medication == null)
        {
            throw new NotFoundException(nameof(Medication), request.Id);
        }

        medication.Name = request.Name;
        medication.Dosage = request.Dosage;
        medication.Instruction = request.Instruction;

        repository.Update(medication);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);
    }
}