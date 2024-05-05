using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;
using MediToring.Domain.Users;
using MediToring.Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Infrastructure;

public class MediToringDbContext : DbContext, IMediToringDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<MedicationSchedule> MedicationSchedules { get; set; }

    public MediToringDbContext(DbContextOptions<MediToringDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationConfiguration());
        modelBuilder.ApplyConfiguration(new MedicationScheduleConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}