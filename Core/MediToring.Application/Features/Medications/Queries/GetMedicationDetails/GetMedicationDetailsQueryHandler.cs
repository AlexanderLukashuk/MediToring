namespace MediToring.Application.Features.Medications.Queries.GetMedicationDetails;

public class GetMedicationDetailsQueryHandler(IMedicationRepository repository, IMapper mapper) 
    : IRequestHandler<GetMedicationDetailsQuery, MedicationDetailsVm>
{
    public async Task<MedicationDetailsVm> Handle(GetMedicationDetailsQuery request, CancellationToken cancellationToken)
    {
        var medication = await repository.Get(request.Id);

        if (medication == null)
        {
            throw new NotFoundException(nameof(Medication), request.Id);
        }

        return mapper.Map<MedicationDetailsVm>(medication);
    }
}