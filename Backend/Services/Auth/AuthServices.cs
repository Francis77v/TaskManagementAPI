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
        try
        {
            var users = await _userManager.FindByNameAsync(user.username);
            if (users != null && await _userManager.CheckPasswordAsync(users, user.password))
            {
                return await GenerateJwtToken(users); 
            }
            return "User not found";
        }
        catch (Exception e)
        {
            return e.Message;
        }
        
    }

    private async Task<string> GenerateJwtToken(Users user)
    {
        var exp = new DateTimeOffset(DateTime.UtcNow.AddMinutes(60)).ToUnixTimeSeconds();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, 
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64),
            new Claim(JwtRegisteredClaimNames.Exp, exp.ToString(), ClaimValueTypes.Integer64)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(_config["Jwt:ExpiresInMinutes"]!)
            ),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}