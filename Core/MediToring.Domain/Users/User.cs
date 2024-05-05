using BuildingBlocks.Domain;
using MediToring.Domain.Enums;
using MediToring.Domain.Medications;

namespace MediToring.Domain.Users;

public class User : EntityBase<Guid>
{
    public string Email { get; private set; }
    public string Name { get; set; }
    public string PasswordHash { get; private set; }
    public Role UserRole { get; set; }
    public ICollection<MedicationSchedule> MedicationSchedules { get; set; }

    private User() { }

    public User(string email, string passwordHash) : this(Guid.NewGuid(), email, passwordHash) { }

    public User(Guid guid, string email, string passwordHash)
    {
        Id = guid;

        Email = email;
        PasswordHash = passwordHash;
    }
}
