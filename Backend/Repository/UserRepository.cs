namespace Backend.Repository;
using Backend.Context;
using Backend.DTO.AuthDTO;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
public class UserRepository
{
    private readonly MyDbContext _context;
    private readonly UserManager<Users> _userManager;

    public UserRepository(MyDbContext context, UserManager<Users> manager)
    {
        _context = context;
        _userManager = manager;
    }

    public async Task<IdentityResult> AddUser(RegisterDTO user)
    {
        var users = new Users
        {
            Email = user.email,
            firstName = user.firstName,
            middleName = user.middleName,
            surName = user.surName,
            UserName = user.username,
        };

        var result = await _userManager.CreateAsync(users, user.password);
        return result;
    }

    public async Task<bool> UserExists(string username, string email)
    {
        var userByName = await _userManager.FindByNameAsync(username);
        var userByEmail = await _userManager.FindByEmailAsync(email);

        return userByName != null || userByEmail != null;
    }

}