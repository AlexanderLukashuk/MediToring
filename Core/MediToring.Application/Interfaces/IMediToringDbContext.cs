namespace MediToring.Application.Interfaces;

public interface IMediToringDbContext
{
    DbSet<Medication> Medications { get; set; }
    DbSet<MedicationSchedule> MedicationSchedules { get; set;}

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}