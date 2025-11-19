using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.DTO.AuthDTO;
using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Backend.Controllers;
namespace Backend.Services.Auth;
using Backend.DTO.AuthDTO;

public class AuthServices
{
    private readonly UserManager<Users> _userManager;
    private readonly IConfiguration _config;
    // private readonly ILogger<AuthController> _logger;
    
    public AuthServices(UserManager<Users> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _config = configuration;
        // _logger = logger;
    }
    
    public async Task<APIResponseDTO<TokenDTO>> ValidateUserAsync(LoginDTO user)
    {
        
        try
        {
            var users = await _userManager.FindByNameAsync(user.username);
            if (users != null && await _userManager.CheckPasswordAsync(users, user.password))
            {
                var tokenString = await GenerateJwtTokenAsync(users);
                return APIResponse.SuccessResponse(tokenString);
            }
            else
            {
                return APIResponse.ErrorResponse<TokenDTO>("User not found.", 404);
            }
        }
        catch (Exception e)
        {
            var response = APIResponse.ErrorResponse<TokenDTO>("Internal Server Error", 500);
            return response;
        }
    }

    private async Task<TokenDTO> GenerateJwtTokenAsync(Users user)
    {
        var expiresInMinutes = double.Parse(_config["Jwt:ExpiresInMinutes"]!);
        var expiration = DateTime.UtcNow.AddMinutes(expiresInMinutes);

        // Access token claims
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, 
                new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim(JwtRegisteredClaimNames.Exp, 
                new DateTimeOffset(expiration).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Create access token
        var accessToken = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );

        var accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);
        var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        return new TokenDTO
        {
            AccessToken = accessTokenString,
            RefreshToken = refreshToken,
        };
    }

}