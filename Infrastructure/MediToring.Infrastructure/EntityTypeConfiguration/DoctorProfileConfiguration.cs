
namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class DoctorProfileConfiguration : IEntityTypeConfiguration<DoctorProfile>
{
    public void Configure(EntityTypeBuilder<DoctorProfile> builder)
    {
        builder.HasKey(dp => dp.Id);
        builder.Property(dp => dp.UserProfileId).IsRequired();
        builder.Property(dp => dp.Specialization).HasMaxLength(100).IsRequired();
        builder.Property(dp => dp.Qualification).HasMaxLength(100).IsRequired();
        builder.Property(dp => dp.ExperienceYears).IsRequired();
        builder.Property(dp => dp.Clinic).HasMaxLength(100);
        builder.Property(dp => dp.Bio).HasMaxLength(1000);
        // builder.Property(dp => dp.Reviews).HasConversion(
        //     v => string.Join(':', v),
        //     v => v.Split(':', StringSplitOptions.RemoveEmptyEntries).ToList()
        // );
        // builder.Property(dp => dp.Rating).HasConversion(
        //     v => string.Join(',', v),
        //     v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
        // );

        builder.HasOne(dp => dp.UserProfile)
            .WithMany()
            .HasForeignKey(dp => dp.UserProfileId);
    }
}