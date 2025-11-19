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

    public async Task<string> AddUser(RegisterDTO user)
    {
        var users = new Users
        {
            Email = user.email,
            firstName = user.firstName,
            middleName = user.middleName,
            surName = user.surName,
            UserName = user.username,
        };

        await _userManager.CreateAsync(users, user.password);
        return "User Added";
    }
}