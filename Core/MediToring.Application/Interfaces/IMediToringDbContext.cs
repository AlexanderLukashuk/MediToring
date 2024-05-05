using MediToring.Domain.Medications;
using MediToring.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Application.Interfaces;

public interface IMediToringDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Medication> Medications { get; set; }
    DbSet<MedicationSchedule> MedicationSchedules { get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}