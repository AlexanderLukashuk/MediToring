namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class MedicationScheduleConfiguration : IEntityTypeConfiguration<MedicationSchedule>
{
    public void Configure(EntityTypeBuilder<MedicationSchedule> builder)
    {
        builder.HasKey(schedule => schedule.Id);
        builder.HasIndex(schedule => schedule.Id).IsUnique();

        builder.HasOne(schedule => schedule.Medication)
            .WithMany(medication => medication.Schedules)
            .HasForeignKey(schedule => schedule.MedicationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<IdentityUser>(schedule => schedule.User)
            .WithMany()
            .HasForeignKey(schedule => schedule.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(schedule => schedule.StartTime).IsRequired();
        builder.Property(schedule => schedule.EndTime).IsRequired();
        builder.Property(schedule => schedule.IsTaken).IsRequired().HasDefaultValue(false);

        builder.OwnsMany(schedule => schedule.DailyDoses, dd =>
        {
            dd.Property(d => d.TimeOfDay).IsRequired();
            dd.Property(d => d.BeforeMeal).IsRequired();
        });
    }
}