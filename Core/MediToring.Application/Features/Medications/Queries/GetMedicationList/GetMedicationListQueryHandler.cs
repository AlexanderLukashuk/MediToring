using MediatR;
using MediToring.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Features.Medications.Queries.GetMedicationList;

public class GetMedicationListQueryHandler(IMediToringDbContext context) 
    : IRequestHandler<GetMedicationListQuery, MedicationListVm>
{
    public async Task<MedicationListVm> Handle(GetMedicationListQuery request, CancellationToken cancellationToken)
    {
        var medications = await context.Medications
            .Select(medication => new MedicationLookupDto
            {
                Name = medication.Name
            })
            .ToListAsync(cancellationToken);

        return new MedicationListVm { Medications = medications };
    }
}