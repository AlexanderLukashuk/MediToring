
namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class DoctorApplicationConfiguration : IEntityTypeConfiguration<DoctorApplication>
{
    public void Configure(EntityTypeBuilder<DoctorApplication> builder)
    {
        builder.HasKey(da => da.Id);
        builder.Property(da => da.UserId).IsRequired();
        builder.Property(da => da.Specialization).HasMaxLength(100).IsRequired();
        builder.Property(da => da.Qualification).HasMaxLength(100).IsRequired();
        builder.Property(da => da.ExperienceYears).IsRequired();
        builder.Property(da => da.Clinic).HasMaxLength(100);
        builder.Property(da => da.Bio).HasMaxLength(1000);
        builder.Property(da => da.Status).IsRequired();
        builder.Property(da => da.SubmittedAt).IsRequired();
    }
}