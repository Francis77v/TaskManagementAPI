namespace Backend.DTO.AuthDTO;

public class RegisterDTO
{
    public string email { get; set; } = null!;
    public string username { get; set; } = null!;
    public string password { get; set; } = null!;
    public string confirmPassword { get; set; } = null!;
    public string firstName { get; set; } = null!;
    public string middleName { get; set; } = null!;
    public string surName { get; set; } = null!;
}