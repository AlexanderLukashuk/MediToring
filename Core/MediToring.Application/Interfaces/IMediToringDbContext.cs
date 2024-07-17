using MediToring.Domain.Models;

namespace MediToring.Application.Interfaces;

public interface IMediToringDbContext
{
    DbSet<Medication> Medications { get; set; }
    DbSet<MedicationSchedule> MedicationSchedules { get; set;}
    DbSet<DailyDoseRecord> DailyDoseRecords { get; set; }
    DbSet<UserProfile> UserProfiles { get; set; }
    DbSet<DoctorApplication> DoctorApplications { get; set; }
    DbSet<DoctorProfile> DoctorProfiles { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}