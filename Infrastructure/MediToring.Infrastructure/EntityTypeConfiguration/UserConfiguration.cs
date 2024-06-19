namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.HasIndex(user => user.Id).IsUnique();

        builder.Property(user => user.Name).IsRequired().HasMaxLength(100);
        
        builder.Property(user => user.Email).IsRequired();
        builder.HasIndex(user => user.Email).IsUnique();
        
        builder.Property(user => user.PasswordHash).IsRequired();
    }
}