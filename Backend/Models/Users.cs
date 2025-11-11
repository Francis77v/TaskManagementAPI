using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

public class Users : IdentityUser
{
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string surName { get; set; }
}