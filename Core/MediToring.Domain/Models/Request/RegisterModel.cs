namespace MediToring.Domain.Models.Request;

public class RegisterModel
{
    [Required(ErrorMessage = "User Name is required")]
    public required string Username { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Required(ErrorMessage = "Email is required")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    public required string Password { get; set; }
}