using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Backend.DTO;
namespace Backend.Services.Auth;

public class AuthServices
{
    private readonly UserManager<Users> _userManager;
    private readonly IConfiguration _config;
    
    public AuthServices(UserManager<Users> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _config = configuration;
    }
    public async Task<String?> ValidateUserAsync(LoginDTO user)
    {
        var users = await _userManager.FindByNameAsync(user.username);
        if (users != null && await _userManager.CheckPasswordAsync(users, user.password))
        {
            return await GenerateJwtToken(users); 
        }
        return null;
    }

    private async Task<string> GenerateJwtToken(Users user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["Jwt:ExpireMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}