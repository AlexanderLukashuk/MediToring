using System.Security.Cryptography;
using BuildingBlocks.Application;
using MediToring.Application.Interfaces;
using MediToring.Domain.Medications;
using MediToring.Domain.Users;
using MediToring.Infrastructure.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediToring.Infrastructure;

public class MediToringDbContext : IdentityDbContext<IdentityUser>, IMediToringDbContext, IUnitOfWork
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

    public async Task<bool> SaveEntitiesASync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }
}