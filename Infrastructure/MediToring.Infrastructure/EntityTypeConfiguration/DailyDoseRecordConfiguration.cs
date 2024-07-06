using MediToring.Domain.Models;

namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class DailyDoseRecordConfiguration : IEntityTypeConfiguration<DailyDoseRecord>
{
    public void Configure(EntityTypeBuilder<DailyDoseRecord> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Date)
            .IsRequired();

        builder.Property(r => r.IsTaken)
            .IsRequired();

        builder.HasOne(r => r.MedicationSchedule)
            .WithMany(s => s.DoseRecords)
            .HasForeignKey(r => r.MedicationScheduleId);

        builder.ToTable("DailyDoseRecords");
    }
}