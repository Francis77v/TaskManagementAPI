using System.ComponentModel.DataAnnotations;

namespace Backend.DTO.AuthDTO;

public class RegisterDTO
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string email { get; set; } = null!;
    [Required(ErrorMessage = "Username is required")]
    public string username { get; set; } = null!;
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, ErrorMessage = "Password must be atleast 8 characters long.", MinimumLength = 8)]
    public string password { get; set; } = null!;
    [Required(ErrorMessage = "Confirm Password is required")]
    public string confirmPassword { get; set; } = null!;
    [Required(ErrorMessage = "First Name is required")]
    public string firstName { get; set; } = null!;
    [Required(ErrorMessage = "Middle Name is required")]
    public string middleName { get; set; } = null!;
    [Required(ErrorMessage = "Sur Name is required")]
    public string surName { get; set; } = null!;
}