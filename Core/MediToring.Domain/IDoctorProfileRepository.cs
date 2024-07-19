using MediToring.Domain.Models;

namespace MediToring.Domain;

public interface IDoctorProfileRepository : IRepository<DoctorProfile>
{
    DoctorProfile Add(DoctorProfile profile);
    Task<DoctorProfile?> Get(Guid id);
    Task<List<DoctorProfile>> GetAll();
    Task Remove(DoctorProfile profile);
}