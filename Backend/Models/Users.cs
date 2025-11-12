using Microsoft.AspNetCore.Identity;

namespace Backend.Models;

public class Users : IdentityUser
{
    public string firstName { get; set; }
    public string middleName { get; set; }
    public string surName { get; set; }
    public ICollection<ProjectTeam> ProjectTeams { get; } = new List<ProjectTeam>();
    public ICollection<Task> Tasks { get; } = new List<Task>();
    public ICollection<Comment> Comments { get; } = new List<Comment>();
}