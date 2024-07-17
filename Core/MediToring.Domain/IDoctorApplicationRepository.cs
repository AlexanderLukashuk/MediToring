using MediToring.Domain.Models;

namespace MediToring.Domain;

public interface IDoctorApplicationRepository : IRepository<DoctorApplication>
{
    DoctorApplication Add(DoctorApplication application);
}