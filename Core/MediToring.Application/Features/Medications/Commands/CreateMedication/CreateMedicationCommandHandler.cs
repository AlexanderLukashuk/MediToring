namespace MediToring.Application.Features.Medications.Commands.CreateMedication;

public class CreateMedicationCommandHandler(IMedicationRepository repository) 
    : IRequestHandler<CraeteMedicationCommand, Guid>
{
    public async Task<Guid> Handle(CraeteMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = new Medication(request.Name, request.Dosage, request.Instruction);

        repository.Add(medication);
        await repository.UnitOfWork.SaveEntitiesASync(cancellationToken);

        return medication.Id;
    }
}