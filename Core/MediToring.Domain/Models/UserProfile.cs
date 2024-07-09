using Microsoft.AspNetCore.Identity;

namespace MediToring.Domain.Models;

public class UserProfile : EntityBase<Guid>, IAggregateRoot
{
    public string UserId { get; set; }

    public string FirstName { get; set;}

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public IdentityUser User { get; set; }

    public UserProfile() { }

    public UserProfile(string userId, string firstName, string lastName, DateTime dateOfBirth, double height = 0, double weight = 0)
        : this(Guid.NewGuid(), userId, firstName, lastName, dateOfBirth, height, weight) { }

    public UserProfile(Guid guid, string userId, string firstName, string lastName, DateTime dateOfBirth, double height = 0, double weight = 0)
    {
        Id = guid;

        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Height = height;
        Weight = weight;
    }
}