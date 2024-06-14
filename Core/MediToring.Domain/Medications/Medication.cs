using BuildingBlocks.Domain;

namespace MediToring.Domain.Medications;

public class Medication : EntityBase<Guid>, IAggregateRoot
{
    public string Name { get; set; }
    public string Dosage { get; set; }
    public string Instruction { get; set; }
    public ICollection<MedicationSchedule> Schedules { get; set; }

    private Medication() { }

    public Medication(string name, string dosage, string instruction)
        : this(Guid.NewGuid(), name, dosage, instruction) { }

    public Medication(Guid guid, string name, string dosage, string instruction)
    {
        Id = guid;

        Name = name;
        Dosage = dosage;
        Instruction = instruction;
    }
}
