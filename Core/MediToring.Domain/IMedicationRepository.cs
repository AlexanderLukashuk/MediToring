using BuildingBlocks.Infrastructure;
using MediToring.Domain.Medications;

namespace MediToring.Domain;

public interface IMedicationRepository : IRepository<Medication>
{
    Medication Add(Medication medication);
    Task<Medication> Get(Guid guid);
    void Delete(Medication medication);
    void Update(Medication medication);
    Task<IEnumerable<Medication>> GetAll();
}
