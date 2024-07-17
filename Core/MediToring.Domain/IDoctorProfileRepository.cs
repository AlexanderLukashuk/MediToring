using MediToring.Domain.Models;

namespace MediToring.Domain;

public interface IDoctorProfileRepository : IRepository<DoctorProfile>
{
    DoctorProfile Add(DoctorProfile profile);
}