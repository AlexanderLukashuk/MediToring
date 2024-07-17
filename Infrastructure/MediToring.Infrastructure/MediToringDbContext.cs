namespace MediToring.Infrastructure;

public class MediToringDbContext : IdentityDbContext<IdentityUser>, IMediToringDbContext, IUnitOfWork
{
    public DbSet<Medication> Medications { get; set; }
    public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
    public DbSet<DailyDoseRecord> DailyDoseRecords { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<DoctorApplication> DoctorApplications { get; set; }
    public DbSet<DoctorProfile> DoctorProfiles { get; set; }

    public MediToringDbContext(DbContextOptions<MediToringDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new DailyDoseRecordConfiguration());
        modelBuilder.ApplyConfiguration(new UserProfileConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorApplicationConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorProfileConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> SaveEntitiesASync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}