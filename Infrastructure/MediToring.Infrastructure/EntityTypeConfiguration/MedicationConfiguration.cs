using MediToring.Domain.Medications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MediToring.Infrastructure.EntityTypeConfiguration;

public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
{
    public void Configure(EntityTypeBuilder<Medication> builder)
    {
        builder.HasKey(medication => medication.Id);
        builder.HasIndex(medication => medication.Id).IsUnique();

        builder.Property(medication => medication.Name).IsRequired().HasMaxLength(250);

        builder.Property(medication => medication.Dosage).IsRequired().HasMaxLength(50);
        
        builder.Property(medication => medication.Instruction).IsRequired().HasMaxLength(250);
    }
}