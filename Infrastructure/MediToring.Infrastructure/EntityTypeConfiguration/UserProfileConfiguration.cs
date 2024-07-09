
namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(profile => profile.Id);
        builder.HasOne(profile => profile.User)
            .WithOne()
            .HasForeignKey<UserProfile>(profile => profile.UserId);

        builder.Property(profile => profile.UserId).IsRequired();
        builder.Property(profile => profile.FirstName).IsRequired();
        builder.Property(profile => profile.LastName).IsRequired();
        builder.Property(profile => profile.DateOfBirth).IsRequired();
    }
}