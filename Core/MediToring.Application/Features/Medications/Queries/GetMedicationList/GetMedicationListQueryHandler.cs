namespace MediToring.Application.Features.Medications.Queries.GetMedicationList;

public class GetMedicationListQueryHandler(IMedicationRepository repository, IMapper mapper) 
    : IRequestHandler<GetMedicationListQuery, MedicationListVm>
{
    public async Task<MedicationListVm> Handle(GetMedicationListQuery request, CancellationToken cancellationToken)
    {
        var medications = await repository.GetAll();

        var medicationDtos = mapper.Map<List<MedicationLookupDto>>(medications);

        return new MedicationListVm { Medications = medicationDtos };
    }
}