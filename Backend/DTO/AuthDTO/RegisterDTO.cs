namespace Backend.DTO.AuthDTO;

public class RegisterDTO
{
    public string email { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string confirmPassword { get; set; }
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string surName { get; set; }
}