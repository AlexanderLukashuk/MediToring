using BuildingBlocks.Domain;

namespace MediToring.Domain.Medications;

public class Medication : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Instruction { get; set; }
    public ICollection<MedicationSchedule> Schedules { get; set; }
}
