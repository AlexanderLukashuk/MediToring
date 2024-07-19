using MediToring.Domain.Models;

namespace MediToring.Domain;

public interface IDoctorApplicationRepository : IRepository<DoctorApplication>
{
    DoctorApplication Add(DoctorApplication application);
    Task<DoctorApplication?> Get(Guid id);
    Task<List<DoctorApplication>> GetAll();
    Task Remove(DoctorApplication application);
}